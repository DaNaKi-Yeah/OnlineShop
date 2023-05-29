using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.DTOs
{
    public class GetOrderDTO : IMapWith<Order>
    {
        public int Id { get; set; }
        public decimal TotalSum { get; set; }
    }
}
