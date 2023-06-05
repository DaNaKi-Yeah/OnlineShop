using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Handlers;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Queries.GetBuyItemById
{
    public class GetBuyItemByIdQueryHandler : BuyItemHandler, IRequestHandler<GetBuyItemByIdQuery, GetBuyItemDTO>
    {
        public GetBuyItemByIdQueryHandler(IRepository<BuyItem, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetBuyItemDTO> Handle(GetBuyItemByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request.Id == 0)
            {
                throw new ArgumentNullException("request is null or BuyItemId = 0");
            }

            var buyItem = await _repository.GetByIdAsync(request.Id);


            var inventory = buyItem.ProductPropertyValuesInventory;

            var getInventory = _mapper.Map<GetBuyItemProductPropertyValuesInventoryDTO>(inventory);
            getInventory.ProductPropertyValueDTOs = _mapper.Map<List<GetBuyItemProductPropertyValueDTO>>(inventory.ProductPropertyValues);


            var getBuyItem = _mapper.Map<GetBuyItemDTO>(buyItem);

            getBuyItem.InventoryDTO = getInventory;

            return getBuyItem;
        }
    }
}
