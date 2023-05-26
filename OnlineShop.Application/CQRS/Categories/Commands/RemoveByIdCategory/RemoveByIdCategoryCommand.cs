using MediatR;

namespace OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty
{
    public class RemoveByIdCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
