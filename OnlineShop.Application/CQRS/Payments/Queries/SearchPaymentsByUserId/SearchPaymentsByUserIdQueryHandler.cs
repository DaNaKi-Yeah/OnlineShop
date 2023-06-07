using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Queries.SearchPaymentsByUserId
{
    public class SearchPaymentsByUserIdQueryHandler : PaymentHandler, IRequestHandler<SearchPaymentsByUserIdQuery, List<GetPaymentDTO>>
    {
        private readonly IRepository<User, int> _userRepository;

        public SearchPaymentsByUserIdQueryHandler(IRepository<Payment, int> repository, IRepository<User, int> userRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetPaymentDTO>> Handle(SearchPaymentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.UserId == 0)
            {
                var allItems = await _repository.GetAllAsync();

                var allGetItems = _mapper.Map<List<GetPaymentDTO>>(allItems);

                foreach (var getItem in allGetItems)
                {
                    var cart = allItems.First(x => x.Id == getItem.Id).Order.Cart;
                    var user = await _userRepository.GetByIdAsync((int)cart.UserId);
                    getItem.FullName = $"{user.FirsName} + {user.LastName}";
                }

                return allGetItems;
            }


            var items = await _repository.GetQuery().Where(x => x.Order.Cart.UserId == request.UserId).ToListAsync();

            var getItems = _mapper.Map<List<GetPaymentDTO>>(items);

            foreach (var getItem in getItems)
            {
                var cart = items.First(x => x.Id == getItem.Id).Order.Cart;
                var user = await _userRepository.GetByIdAsync((int)cart.UserId);
                getItem.FullName = $"{user.FirsName} + {user.LastName}";
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
