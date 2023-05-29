using MediatR;

using OnlineShop.Application.CQRS.Orders.DTOs;

namespace OnlineShop.Application.CQRS.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderDTO>
    {
        public int Id { get; set; }
    }
}
