using System.IdentityModel.Tokens.Jwt;

using IdentityServer4.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OnlineShop.API.Identity;
using OnlineShop.API.JWT;
using OnlineShop.Application.CQRS.Users.Commands.CreateUser;
using OnlineShop.Domain.Models;
using OnlineShop.Persistence.Db.SqlServer;

using ITokenService = OnlineShop.API.JWT.ITokenService;

namespace OnlineShop.API.Controllers
{
    [ApiController]    
    [Route("accounts")]
    public class AccountsController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SQLServerOnlineShopDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AccountsController(
            ITokenService tokenService, 
            SQLServerOnlineShopDbContext context, 
            UserManager<UserAccount> userManager, 
            IConfiguration configuration,
            IMediator mediator)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var userAccount = _context.UserAccounts.FirstOrDefault(u => u.Email == request.Email);

            if (userAccount is null)
                return Unauthorized();

            var roleIds = await _context.UserRoles.Where(r => r.UserId == userAccount.Id).Select(x => x.RoleId).ToListAsync();
            var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = _tokenService.CreateToken(userAccount, roles);
            userAccount.RefreshToken = _configuration.GenerateRefreshToken();
            userAccount.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Id = userAccount.Id,
                Username = userAccount.UserName!,
                Email = userAccount.Email!,
                Token = accessToken,
                RefreshToken = userAccount.RefreshToken
            });
        }

        [HttpPost("register/admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<AuthResponse>> RegisterAdmin([FromBody] RegisterRequest request)
        {
            return await RegisterNewUser(request, "admin");
        }

        [AllowAnonymous]
        [HttpPost("register/client")]
        public async Task<ActionResult<AuthResponse>> RegisterClient([FromBody] RegisterRequest request)
        {
            return await RegisterNewUser(request, "client");
        }

        private async Task<ActionResult<AuthResponse>> RegisterNewUser(RegisterRequest request, string roleName)
        {
            if (!ModelState.IsValid) return BadRequest(request);

            var userAccount = new UserAccount
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email
            };
            var result = await _userManager.CreateAsync(userAccount, request.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            if (!result.Succeeded) return BadRequest(ModelState);

            var findUser = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Email == request.Email);

            await _mediator.Send(new CreateUserCommand() { UserAccountId = findUser.Id });

            if (findUser == null) throw new Exception($"User {request.Email} not found");

            await _userManager.AddToRoleAsync(findUser, roleName);

            return await Authenticate(new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var username = principal.Identity!.Name;
            var userAccount = await _userManager.FindByNameAsync(username!);

            if (userAccount == null || userAccount.RefreshToken != refreshToken || userAccount.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            userAccount.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(userAccount);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            var userAccount = await _userManager.FindByNameAsync(username);
            if (userAccount == null) return BadRequest("Invalid user name");

            userAccount.RefreshToken = null;
            await _userManager.UpdateAsync(userAccount);

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var userAccount in users)
            {
                userAccount.RefreshToken = null;
                await _userManager.UpdateAsync(userAccount);
            }

            return Ok();
        }
    }
}