using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest, IMapWith<Cart>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCartCommand, Cart>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.UserId))
                .ForMember(x => x.OrderId, opt => opt.MapFrom(y => y.OrderId));
        }
    }
}
