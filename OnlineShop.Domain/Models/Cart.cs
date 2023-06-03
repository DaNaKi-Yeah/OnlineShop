using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Cart : BaseEntity<int>
    {
        public decimal TotalSum
        {
            get
            {
                decimal sum = 0;

                foreach (var item in BuyItems)
                {
                    sum += item.ProductPropertyValuesInventory.Product.Price * item.Count;
                }

                return sum;
            }
        }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<BuyItem> BuyItems { get; set; }
    }
}
