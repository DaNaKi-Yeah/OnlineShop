using OnlineShop.Domain.Common;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Models
{
    public class ProductPropertyValue : BaseEnitity<int>
    {
        public int PropertyValueId { get; set; }
        public PropertyValue PropertyValue { get; set; }
    }
}
