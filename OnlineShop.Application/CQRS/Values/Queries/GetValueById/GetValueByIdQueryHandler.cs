using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.DTOs;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Queries.GetValue
{
    public class GetValueByIdQueryHandler : ValueHandler, IRequestHandler<GetValueByIdQuery, GetValueDTO>
    {
        public GetValueByIdQueryHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetValueDTO> Handle(GetValueByIdQuery request, CancellationToken cancellationToken)
        {
            Value value = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetValueDTO>(value);
        }
    }
}
