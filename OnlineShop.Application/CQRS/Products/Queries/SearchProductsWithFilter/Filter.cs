using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProductsWithFilters
{
    public class Filter
    {
        public List<int?> PropertyValueIds { get; set; }
    }
}