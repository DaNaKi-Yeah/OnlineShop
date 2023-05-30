using OnlineShop.Application.CQRS.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Categories.DTOs
{
    public class GetCategoryProductsDTO
    {
        public string Name { get; set; }
        public List<SearchProductDTO> Products { get; set; }
    }
}
