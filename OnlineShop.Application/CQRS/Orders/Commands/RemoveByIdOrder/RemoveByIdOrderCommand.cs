using MediatR;

namespace OnlineShop.Application.CQRS.Orders.Commands.RemoveByIdOrder
{
    public class RemoveByIdOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
