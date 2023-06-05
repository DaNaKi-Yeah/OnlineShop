using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItems
{
    public class SearchBuyItemsQueryHandler : BuyItemHandler, IRequestHandler<SearchBuyItemsQuery, List<GetBuyItemDTO>>
    {
        public SearchBuyItemsQueryHandler(IRepository<BuyItem, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetBuyItemDTO>> Handle(SearchBuyItemsQuery request, CancellationToken cancellationToken)
        {
            var buyItems = _mapper.Map<List<GetBuyItemDTO>>(await _repository.GetAllAsync());

            if (request.PageSize == null || request.PageNumber == null)
            {
                return buyItems;
            }

            return buyItems
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
