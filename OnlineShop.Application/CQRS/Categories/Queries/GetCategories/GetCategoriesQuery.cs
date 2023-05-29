using MediatR;

using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<GetCategoryDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
