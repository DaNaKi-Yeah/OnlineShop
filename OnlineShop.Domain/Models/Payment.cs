using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Payment: BaseEnitity<int>
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
