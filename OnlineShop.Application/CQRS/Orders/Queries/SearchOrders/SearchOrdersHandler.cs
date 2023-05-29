using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Orders.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Queries.GetOrders
{
    public class SearchOrdersHandler : OrderHandler, IRequestHandler<SearchOrdersQuery, List<GetOrderDTO>>
    {
        public SearchOrdersHandler(IRepository<Order, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetOrderDTO>> Handle(SearchOrdersQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.ClientId == 0)
            {
                return _mapper.Map<List<GetOrderDTO>>(await _repository.GetAllAsync());
            }


            var baseResult = _mapper.Map<List<GetOrderDTO>>(await _repository.GetQuery().Where(x => x.Cart.ClientId == request.ClientId)
                .AsNoTracking()
                .ToListAsync());

            if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
