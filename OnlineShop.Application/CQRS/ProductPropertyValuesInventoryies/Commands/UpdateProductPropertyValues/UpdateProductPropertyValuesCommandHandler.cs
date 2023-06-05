using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.CreateProductPropertyValuesInventory;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.UpdateProductPropertyValues
{
    public class UpdateProductPropertyValuesCommandHandler :
        ProductPropertyValuesInventoryHandler,
        IRequestHandler<UpdateProductPropertyValuesCommand>
    {
        public UpdateProductPropertyValuesCommandHandler(IRepository<ProductPropertyValuesInventory, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateProductPropertyValuesCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _repository.GetByIdAsync(request.InventoryId);

            inventory.Count = request.Count;

            await _repository.UpdateAsync(inventory);
        }
    }
}
