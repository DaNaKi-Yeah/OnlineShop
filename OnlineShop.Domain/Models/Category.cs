using OnlineShop.Domain.Common;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Domain.Models
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual List<CategoryProperty> CategoryProperties { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
