using OnlineShop.Domain.Common;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Domain.Models
{
    public class ProductPropertyValue : BaseEnitity<int>
    {
        public int PropertyValueId { get; set; }
        public PropertyValue PropertyValue { get; set; }
    }
}
