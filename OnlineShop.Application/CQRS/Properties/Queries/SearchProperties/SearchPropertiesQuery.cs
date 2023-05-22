using MediatR;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Queries.SearchProperties
{
    public class SearchPropertiesQuery : IRequest<List<Property>>
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
