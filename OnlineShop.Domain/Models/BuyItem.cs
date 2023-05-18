using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class BuyItem: BaseEnitity<int>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int Count { get; set; }
    }
}
