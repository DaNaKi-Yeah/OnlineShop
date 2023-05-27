using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Client: BaseEntity<int>
    {
        public virtual List<Cart> Carts { get; set; }
        public virtual List<BankAccount> BankAccounts { get; set; }
    }
}
