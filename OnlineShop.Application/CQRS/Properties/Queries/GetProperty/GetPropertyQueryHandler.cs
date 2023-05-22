using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Queries.GetProperty
{
    public class GetPropertyQueryHandler : PropertyHandler, IRequestHandler<GetPropertyQuery, Property>
    {
        public GetPropertyQueryHandler(IRepository<Property, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<Property> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            Property property = await _repository.GetByIdAsync(request.Id);

            return property;
        }
    }
}
