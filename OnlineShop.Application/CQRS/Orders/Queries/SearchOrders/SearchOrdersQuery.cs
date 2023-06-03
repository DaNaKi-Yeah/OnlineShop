using MediatR;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Queries.GetOrders
{
    public class SearchOrdersQuery : IRequest<List<GetOrderDTO>>
    {
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
