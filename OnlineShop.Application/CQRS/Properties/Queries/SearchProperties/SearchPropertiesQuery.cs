using MediatR;

using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Queries.SearchProperties
{
    public class SearchPropertiesQuery : IRequest<List<GetPropertyDTO>>
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
