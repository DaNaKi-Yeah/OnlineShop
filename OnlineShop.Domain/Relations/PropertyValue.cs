using OnlineShop.Domain.Common;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
