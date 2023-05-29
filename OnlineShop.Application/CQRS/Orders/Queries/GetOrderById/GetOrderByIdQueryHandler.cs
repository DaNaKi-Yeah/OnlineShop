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
        public GetOrderByIdQueryHandler(IRepository<Order, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetOrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order order = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetOrderDTO>(order);
        }
    }
}
