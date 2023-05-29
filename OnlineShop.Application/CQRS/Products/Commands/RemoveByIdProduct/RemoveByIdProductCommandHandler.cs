using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Commands.RemoveByIdProduct
{
    public class RemoveByIdProductCommandHandler : ProductHandler, IRequestHandler<RemoveByIdProductCommand>
    {
        public RemoveByIdProductCommandHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
