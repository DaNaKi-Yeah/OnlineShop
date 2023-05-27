using OnlineShop.Domain.Common;
using OnlineShop.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Relations
{
    public class ProductPropertyValue : BaseEntity<int>
    {
        public int? PropertyValueId { get; set; }
        public virtual PropertyValue? PropertyValue { get; set; }
        public int ProductPropertyValuesInventoryId { get; set; }
        public virtual ProductPropertyValuesInventory ProductPropertyValuesInventory { get; set; }
    }
}
