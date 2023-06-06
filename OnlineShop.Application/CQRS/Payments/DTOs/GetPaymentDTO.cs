using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.DTOs
{
    public class GetPaymentDTO : IMapWith<Payment>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int OrderId { get; set; }
        public int BankAccountId { get; set; }
        public decimal TotalSum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, GetPaymentDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.Order.Cart.UserId))
                .ForMember(x => x.OrderId, opt => opt.MapFrom(y => y.OrderId))
                .ForMember(x => x.BankAccountId, opt => opt.MapFrom(y => y.BankAccountId))
                .ForMember(x => x.TotalSum, opt => opt.MapFrom(y => y.TotalSum));
        }
    }
}
