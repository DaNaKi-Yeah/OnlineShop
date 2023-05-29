using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.DTOs
{
    public class GetPaymentDTO : IMapWith<Payment>
    {
        public int Id { get; set; }     
        public decimal TotalSum { get; set; }
    }
}
