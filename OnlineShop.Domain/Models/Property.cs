using OnlineShop.Domain.Common;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Domain.Models
{
    public class Property : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual List<CategoryProperty> CategoryProperties { get; set; }
        public virtual List<PropertyValue> PropertyValues { get; set; }
    }
}
