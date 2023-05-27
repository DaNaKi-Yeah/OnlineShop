using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Payments.Commands.RemoveByIdPayment;
using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Commands.RemoveByIdProperty
{
    public class RemoveByIdPropertyCommandHandler : PropertyHandler, IRequestHandler<RemoveByIdPropertyCommand>
    {
        public RemoveByIdPropertyCommandHandler(IRepository<Property, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdPropertyCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
