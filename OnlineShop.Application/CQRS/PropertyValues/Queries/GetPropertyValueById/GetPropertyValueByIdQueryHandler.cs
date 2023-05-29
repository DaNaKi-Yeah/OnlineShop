using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueById
{
    public class GetPropertyValueQueryHandler : PropertyValueHandler, IRequestHandler<GetPropertyValueByIdQuery, GetPropertyValueDTO>
    {
        public GetPropertyValueQueryHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetPropertyValueDTO> Handle(GetPropertyValueByIdQuery request, CancellationToken cancellationToken)
        {
            var propertyValue = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetPropertyValueDTO>(propertyValue);
        }
    }
}
