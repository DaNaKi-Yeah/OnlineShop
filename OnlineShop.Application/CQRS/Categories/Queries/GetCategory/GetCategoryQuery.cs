using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
