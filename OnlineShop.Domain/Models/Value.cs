using OnlineShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Models
{
    public class Value : BaseEnitity<int>
    {
        public string Name { get; set; }
    }
}
