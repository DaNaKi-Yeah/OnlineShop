using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.SearchCategories
{
    public class SearchCategoriesQuery : IRequest<List<Category>>
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
