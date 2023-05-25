using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Commands.RemoveByIdValue
{
    public class RemoveByIdValueCommandHandler : ValueHandler, IRequestHandler<RemoveByIdValueCommand>
    {
        public RemoveByIdValueCommandHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdValueCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
