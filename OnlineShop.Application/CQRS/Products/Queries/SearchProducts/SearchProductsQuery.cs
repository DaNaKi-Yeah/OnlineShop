using MediatR;

using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProducts
{
    public class SearchProductsQuery : IRequest<List<SearchProductDTO>>
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
