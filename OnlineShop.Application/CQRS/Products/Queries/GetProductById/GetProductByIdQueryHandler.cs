using AutoMapper;

using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : ProductHandler, IRequestHandler<GetProductByIdQuery, GetProductDTO>
    {
        private readonly IRepository<ProductPropertyValuesInventory, int> _inventoryRepository;

        public GetProductByIdQueryHandler(IRepository<Product, int> repository, IRepository<ProductPropertyValuesInventory, int> inventoryRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetByIdAsync(request.Id);

            var productDTO = _mapper.Map<GetProductDTO>(product);

            List<GetProductPropertyValuesInventoryVM> inventoryDTOs = new List<GetProductPropertyValuesInventoryVM>();

            var inventories = await _inventoryRepository.GetQuery().Where(i => i.ProductId == product.Id).ToListAsync();

            foreach (var inventory in inventories)
            {
                var inventoryDTO = _mapper.Map<GetProductPropertyValuesInventoryVM>(inventory);
                    
                inventoryDTO.PropertyValues = _mapper.Map<List<GetPropertyValueVM>>(inventory.ProductPropertyValues);

                inventoryDTOs.Add(inventoryDTO);
            }

            productDTO.ProductPropertyValuesInventories = inventoryDTOs;

            return productDTO;
        }
    }
}
