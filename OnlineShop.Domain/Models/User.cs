using Microsoft.AspNetCore.Identity;

using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class User: IdentityUser<int>
    {
        public virtual List<Cart> Carts { get; set; }
        public virtual List<BankAccount> BankAccounts { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
