using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Orders.DTOs
{
    public class SearchOrderDTO : IMapWith<Order>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalSum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, SearchOrderDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.Cart.UserId))
                .ForMember(x => x.PaymentId, opt => opt.MapFrom(y => y.PaymentId))
                .ForMember(x => x.TotalSum, opt => opt.MapFrom(y => y.TotalSum));
        }
    }
}
