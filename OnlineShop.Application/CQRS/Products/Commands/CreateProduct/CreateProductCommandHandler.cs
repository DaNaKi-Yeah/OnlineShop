using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ProductHandler, IRequestHandler<CreateProductCommand, int>
    {
        public CreateProductCommandHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            int id = await _repository.AddAsync(product);

            return id;
        }
    }
}
