using OnlineShop.Domain.Common;
using OnlineShop.Domain.Models;

namespace OnlineShop.Domain.Relations
{
    public class PropertyValue : BaseEntity<int>
    {
        public int? PropertyId { get; set; }
        public virtual Property? Property { get; set; }
        public int? ValueId { get; set; }
        public virtual Value? Value { get; set; }
        public virtual List<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
