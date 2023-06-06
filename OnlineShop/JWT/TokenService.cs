

using Microsoft.AspNetCore.Identity;

using OnlineShop.Domain.Models;
using OnlineShop.API.JWT;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OnlineShop.API.JWT;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(UserAccount userAccount, List<IdentityRole<int>> roles)
    {
        var token = userAccount
            .CreateClaims(roles)
            .CreateJwtToken(_configuration);
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}