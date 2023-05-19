using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Payment: BaseEnitity<int>
    {
        public decimal TotalSum { get { return Order.TotalSum; } }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
