using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int CartId { get; set; }
        public int PaymentId { get; set; }
    }
}
