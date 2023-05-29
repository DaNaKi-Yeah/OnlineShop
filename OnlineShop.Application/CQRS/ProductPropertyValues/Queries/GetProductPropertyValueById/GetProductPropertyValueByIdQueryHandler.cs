using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValues.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValueById
{
    public class GetProductPropertyValueByIdQueryHandler : ProductPropertyValueHandler, IRequestHandler<GetProductPropertyValueByIdQuery, GetProductPropertyValueDTO>
    {
        public GetProductPropertyValueByIdQueryHandler(IRepository<ProductPropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetProductPropertyValueDTO> Handle(GetProductPropertyValueByIdQuery request, CancellationToken cancellationToken)
        {
            var productPropertyValue = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetProductPropertyValueDTO>(productPropertyValue);
        }
    }
}
