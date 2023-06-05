using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Handlers;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId
{
    public class SearchBuyItemsByUserIdQueryHandler : BuyItemHandler, IRequestHandler<SearchBuyItemsByUserIdQuery, List<GetBuyItemDTO>>
    {
        private readonly IRepository<User, int> _userRepository;

        public SearchBuyItemsByUserIdQueryHandler
            (IRepository<BuyItem, int> repository,
            IRepository<User, int> userRepository,
            IMapper mapper) : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetBuyItemDTO>> Handle(SearchBuyItemsByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException("request is null");
            }

            var cartId = (await _userRepository.GetByIdAsync(request.UserId)).CartId;

            var buyItems = (await _repository.GetQuery()
                    .Where(obj => obj.CartId == cartId)
                    .ToListAsync());

            var getBuyItems = new List<GetBuyItemDTO>();


            foreach (var item in buyItems)
            {
                var inventory = item.ProductPropertyValuesInventory;

                var getInventory = _mapper.Map<GetBuyItemProductPropertyValuesInventoryDTO>(inventory);
                getInventory.ProductPropertyValueDTOs = _mapper.Map<List<GetBuyItemProductPropertyValueDTO>>(inventory.ProductPropertyValues);


                var getBuyItem = _mapper.Map<GetBuyItemDTO>(item);
                getBuyItem.InventoryDTO = getInventory;

                getBuyItems.Add(getBuyItem);
            }


            if (request.PageSize == null || request.PageNumber == null)
            {
                return getBuyItems;
            }

            return getBuyItems
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();

        }
    }
}
