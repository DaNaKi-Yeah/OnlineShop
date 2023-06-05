using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.DTOs
{
    public class GetBuyItemDTO : IMapWith<BuyItem>
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int InventoryId { get; set; }
        public GetBuyItemProductPropertyValuesInventoryDTO InventoryDTO { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuyItem, GetBuyItemDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.CartId, opt => opt.MapFrom(y => y.CartId))
                .ForMember(x => x.ProductName, opt => opt.MapFrom(y => y.ProductPropertyValuesInventory.Product.ModelName))
                .ForMember(x => x.Count, opt => opt.MapFrom(y => y.Count))
                .ForMember(x => x.InventoryId, opt => opt.MapFrom(y => y.ProductPropertyValuesInventoryId));
        }
    }
}
