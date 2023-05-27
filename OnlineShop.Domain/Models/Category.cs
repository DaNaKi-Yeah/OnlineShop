using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
