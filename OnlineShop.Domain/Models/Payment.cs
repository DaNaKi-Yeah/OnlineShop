using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Payment: BaseEnitity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string CardNumber { get; set; }
        public string CardOwner { get; set; }
        public string CardCW { get; set; }
    }
}
