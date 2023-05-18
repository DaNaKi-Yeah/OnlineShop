using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Cart: BaseEnitity<int>
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
