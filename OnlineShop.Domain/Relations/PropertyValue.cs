using OnlineShop.Domain.Common;
using OnlineShop.Domain.Models;

namespace OnlineShop.Domain.Relations
{
    public class PropertyValue : BaseEnitity<int>
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int ValueId { get; set; }
        public Value Value { get; set; }
    }
}
