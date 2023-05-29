using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.RemoveProductPropertyValuesInventoryById
{
    public class RemoveProductPropertyValuesInventoryByIdCommandHandler :
         ProductPropertyValuesInventoryHandler,
        IRequestHandler<RemoveProductPropertyValuesInventoryByIdCommand>
    {
        public RemoveProductPropertyValuesInventoryByIdCommandHandler(IRepository<ProductPropertyValuesInventory, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveProductPropertyValuesInventoryByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
