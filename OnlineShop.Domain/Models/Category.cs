using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
