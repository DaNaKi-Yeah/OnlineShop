using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Commands.CreateValue
{
    public class CreateValueCommandHandler : ValueHandler, IRequestHandler<CreateValueCommand, int>
    {
        public CreateValueCommandHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateValueCommand request, CancellationToken cancellationToken)
        {
            Value value = new Value { Name = request.Name };

            int id = await _repository.AddAsync(property);

            return id;
        }
    }
}
