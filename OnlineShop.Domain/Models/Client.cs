using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Client: BaseEnitity<int>
    {
        public List<Cart> Carts { get; set; }
    }
}
