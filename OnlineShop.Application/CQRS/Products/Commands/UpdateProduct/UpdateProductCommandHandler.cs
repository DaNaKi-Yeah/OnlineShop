using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : ProductHandler, IRequestHandler<UpdateProductCommand>
    {
        public UpdateProductCommandHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            product = _mapper.Map<Product>(request);

            await _repository.UpdateAsync(product);
        }
    }
}
