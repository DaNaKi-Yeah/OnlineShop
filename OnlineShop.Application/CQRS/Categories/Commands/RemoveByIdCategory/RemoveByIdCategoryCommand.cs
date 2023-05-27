using MediatR;

namespace OnlineShop.Application.CQRS.Categories.Commands.RemoveByIdCategory
{
    public class RemoveByIdCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
