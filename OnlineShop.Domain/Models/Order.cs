using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Order: BaseEnitity<int>
    {
        public decimal TotalSum { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
