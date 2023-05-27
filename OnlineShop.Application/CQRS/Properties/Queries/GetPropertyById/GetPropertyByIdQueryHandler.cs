using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Queries.GetProperty
{
    public class GetPropertyByIdQueryHandler : PropertyHandler, IRequestHandler<GetPropertyByIdQuery, GetPropertyDTO>
    {
        public GetPropertyByIdQueryHandler(IRepository<Property, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetPropertyDTO> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            Property property = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetPropertyDTO>(property);
        }
    }
}
