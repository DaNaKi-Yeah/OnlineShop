using MediatR;

using OnlineShop.Application.CQRS.Properties.DTOs;

namespace OnlineShop.Application.CQRS.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderDTO>
    {
        public int Id { get; set; }
    }
}
