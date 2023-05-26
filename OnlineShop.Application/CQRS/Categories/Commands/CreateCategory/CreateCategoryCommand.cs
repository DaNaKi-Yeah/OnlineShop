using MediatR;

namespace OnlineShop.Application.CQRS.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
