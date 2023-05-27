using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : OrderHandler, IRequestHandler<CreateOrderCommand, int>
    {
        public CreateOrderCommandHandler(IRepository<Order, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order { CartId = request.CartId, PaymentId = request.PaymentId };

            int id = await _repository.AddAsync(order);

            return id;
        }
    }
}
