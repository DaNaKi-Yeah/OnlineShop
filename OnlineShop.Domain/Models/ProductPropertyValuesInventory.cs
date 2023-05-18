using OnlineShop.Domain.Relations;

namespace OnlineShop.Domain.Models
{
    public class ProductPropertyValuesInventory
    {
        public int Count { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
