using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventoryById
{
    public class GetProductPropertyValuesInventoryByIdCommandHandler : 
        ProductPropertyValuesInventoryHandler, 
        IRequestHandler<GetProductPropertyValuesInventoryByIdCommand, GetProductPropertyValuesInventoryDTO>
    {
        public GetProductPropertyValuesInventoryByIdCommandHandler(IRepository<ProductPropertyValuesInventory, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetProductPropertyValuesInventoryDTO> Handle(GetProductPropertyValuesInventoryByIdCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id);

            var result = _mapper.Map<GetProductPropertyValuesInventoryDTO>(item);

            result.ProductPropertyValueDTOs = _mapper.Map<List<GetProductPropertyValueDTO>>(item.ProductPropertyValues);

            return result;
        }
    }
}
