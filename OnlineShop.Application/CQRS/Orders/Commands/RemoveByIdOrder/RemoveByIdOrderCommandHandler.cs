using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Orders.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Commands.RemoveByIdOrder
{
    public class RemoveByIdOrderCommandHandler : OrderHandler, IRequestHandler<RemoveByIdOrderCommand>
    {
        public RemoveByIdOrderCommandHandler(IRepository<Order, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
