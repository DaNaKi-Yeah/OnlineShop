using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Queries.SearchValues
{
    public class SearchValueQuery : IRequest<List<Value>>
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
