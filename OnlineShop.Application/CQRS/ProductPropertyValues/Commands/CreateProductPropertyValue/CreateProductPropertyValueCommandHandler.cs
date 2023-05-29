using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValues.Handlers;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Commands.CreateProductPropertyValue
{
    public class CreateProductPropertyValueCommandHandler : ProductPropertyValueHandler, IRequestHandler<CreateProductPropertyValueCommand, int>
    {
        public CreateProductPropertyValueCommandHandler(IRepository<ProductPropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateProductPropertyValueCommand request, CancellationToken cancellationToken)
        {
            var productPropertyValue = _mapper.Map<ProductPropertyValue>(request);

            var id = await _repository.AddAsync(productPropertyValue);

            return id;
        }
    }
}
