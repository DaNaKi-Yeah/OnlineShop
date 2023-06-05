using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.DTOs
{
    public class GetBuyItemProductPropertyValuesInventoryDTO : IMapWith<ProductPropertyValuesInventory>
    {
        public int PropertyValuesCount { get; set; }
        public List<GetBuyItemProductPropertyValueDTO> ProductPropertyValueDTOs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPropertyValuesInventory, GetProductPropertyValuesInventoryDTO>()
                .ForMember(y => y.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(y => y.PropertyValuesCount, opt => opt.MapFrom(x => x.ProductPropertyValues.Count));
        }
    }
}
