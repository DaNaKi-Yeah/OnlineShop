using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class BuyItem: BaseEntity<int>
    {
        public int Count { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
