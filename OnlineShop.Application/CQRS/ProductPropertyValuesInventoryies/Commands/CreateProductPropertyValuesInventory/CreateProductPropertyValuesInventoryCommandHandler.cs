using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.CreateProductPropertyValuesInventory
{
    public class CreateProductPropertyValuesInventoryCommandHandler : 
        ProductPropertyValuesInventoryHandler, 
        IRequestHandler<CreateProductPropertyValuesInventoryCommand, int>
    {
        public CreateProductPropertyValuesInventoryCommandHandler(IRepository<ProductPropertyValuesInventory, int> repository, IMapper mapper) : base(repository, mapper) { }

        public Task<int> Handle(CreateProductPropertyValuesInventoryCommand request, CancellationToken cancellationToken)
        {
            var item = new ProductPropertyValuesInventory { Count= request.Count , ProductId = request.ProductId };

            var id = _repository.AddAsync(item);

            return id;
        }
    }
}
