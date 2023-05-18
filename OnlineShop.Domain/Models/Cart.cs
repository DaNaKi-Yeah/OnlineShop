using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Cart: BaseEnitity<int>
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<BuyItem> BuyItems { get; set; }
    }
}
