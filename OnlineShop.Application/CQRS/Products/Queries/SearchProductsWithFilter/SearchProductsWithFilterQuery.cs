using MediatR;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProductsWithFilters
{
    public class SearchProductsWithFilterQuery : IRequest<List<SearchProductDTO>>
    {
        public Filter Filter { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
