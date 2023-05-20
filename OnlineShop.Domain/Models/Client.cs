using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Client: BaseEntity<int>
    {
        public List<Cart> Carts { get; set; }
    }
}
