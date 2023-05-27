using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class BuyItem: BaseEntity<int>
    {
        public int Count { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
