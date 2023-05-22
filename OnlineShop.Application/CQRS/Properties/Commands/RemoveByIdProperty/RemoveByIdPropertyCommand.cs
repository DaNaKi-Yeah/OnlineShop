using MediatR;

namespace OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty
{
    public class RemoveByIdPropertyCommand : IRequest
    {
        public int Id { get; set; }
    }
}
