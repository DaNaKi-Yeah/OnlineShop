using OnlineShop.Domain.Common;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Domain.Models
{
    public class ProductPropertyValuesInventory : BaseEntity<int>
    {
        public int Count { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
