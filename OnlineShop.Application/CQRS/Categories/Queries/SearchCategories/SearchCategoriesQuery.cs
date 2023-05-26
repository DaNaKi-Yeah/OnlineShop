using MediatR;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.SearchCategories
{
    public class SearchCategoriesQuery : IRequest<List<GetCategoryDTO>>
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
