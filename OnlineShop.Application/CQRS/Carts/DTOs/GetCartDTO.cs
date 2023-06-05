using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.DTOs
{
    public class GetCartDTO: IMapWith<Cart>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal TotalSum { get; set; }
        public int BuyItemsCount { get; set; }
        public List<GetBuyItemDTO> BuyItems { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cart, GetCartDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.UserId))
                .ForMember(x => x.TotalSum, opt => opt.MapFrom(y => y.TotalSum))
                .ForMember(x => x.BuyItemsCount, opt => opt.MapFrom(y => y.BuyItems.Count));
        }
    }
}
