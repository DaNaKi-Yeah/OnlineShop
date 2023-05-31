using OnlineShop.Domain.Common;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Relations
{
    public class CategoryProperty : BaseEntity<int>
    {
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int? PropertyId { get; set; }
        public virtual Property? Property { get; set; }
    }
}
