using Microsoft.AspNetCore.Identity;

using OnlineShop.Domain.Models;

namespace OnlineShop.API.JWT;

public interface ITokenService
{
    string CreateToken(UserAccount userAccount, List<IdentityRole<int>> role);
}