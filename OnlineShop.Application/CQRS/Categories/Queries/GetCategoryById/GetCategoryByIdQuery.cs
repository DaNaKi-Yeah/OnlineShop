using MediatR;

using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryDTO>
    {
        public int Id { get; set; }
    }
}
