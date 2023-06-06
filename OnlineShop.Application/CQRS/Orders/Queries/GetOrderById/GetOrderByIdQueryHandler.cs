using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Orders.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : OrderHandler, IRequestHandler<GetOrderByIdQuery, GetOrderDTO>
    {
        private readonly IRepository<User, int> _userRepository;

        public GetOrderByIdQueryHandler(IRepository<Order, int> repository, IRepository<User, int> userRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<GetOrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order order = await _repository.GetByIdAsync(request.Id);

            var getOrder = _mapper.Map<GetOrderDTO>(order);

            getOrder.UserName = (await _userRepository.GetByIdAsync((int)order.Cart.UserId)).UserName;

            return getOrder;
        }
    }
}
