using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Orders.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Queries.SearchOrdersByUserId
{
    public class SearchOrdersByUserIdQueryHandler : OrderHandler, IRequestHandler<SearchOrdersByUserIdQuery, List<GetOrderDTO>>
    {
        private readonly IRepository<User, int> _userRepository;

        public SearchOrdersByUserIdQueryHandler(IRepository<Order, int> repository, IRepository<User, int> userRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetOrderDTO>> Handle(SearchOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.UserId == 0)
            {
                var allItems = await _repository.GetAllAsync();

                var allGetItems = _mapper.Map<List<GetOrderDTO>>(allItems);

                foreach (var getItem in allGetItems)
                {
                    var cart = allItems.First(x => x.Id == getItem.Id).Cart;
                    var user = await _userRepository.GetByIdAsync((int)cart.UserId);
                    getItem.UserName = user.UserName;
                }

                return allGetItems;
            }


            var items = await _repository.GetQuery().Where(x => x.Cart.UserId == request.UserId).ToListAsync();

            var getItems = _mapper.Map<List<GetOrderDTO>>(items);

            foreach (var getItem in getItems)
            {
                var cart = items.First(x => x.Id == getItem.Id).Cart;
                var user = await _userRepository.GetByIdAsync((int)cart.UserId);
                getItem.UserName = user.UserName;
            }


            if (request.PageSize == null || request.PageNumber == null)
            {
                return getItems;
            }

            return getItems
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
