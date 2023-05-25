using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Queries.GetValue
{
    public class GetValueQueryHandler : ValueHandler, IRequestHandler<GetValueQuery, Value>
    {
        public GetValueQueryHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<Value> Handle(GetValueQuery request, CancellationToken cancellationToken)
        {
            Value value = await _repository.GetByIdAsync(request.Id);

            return value;
        }
    }
}
