using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Cart : BaseEnitity<int>
    {
        public decimal TotalSum
        {
            get
            {
                decimal sum = 0;

                foreach (var item in BuyItems)
                {
                    sum += item.Product.Price * item.Count;
                }

                return sum;
            }
        }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<BuyItem> BuyItems { get; set; }
    }
}
