using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs
{
    public class GetProductPropertyValuesInventoryDTO : IMapWith<ProductPropertyValuesInventory>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public int PropertyValuesCount { get; set; }
        public List<GetProductPropertyValueDTO> ProductPropertyValueDTOs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPropertyValuesInventory, GetProductPropertyValuesInventoryDTO>()
                .ForMember(y => y.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(y => y.ProductId, opt => opt.MapFrom(x => x.ProductId))
                .ForMember(y => y.ProductName, opt => opt.MapFrom(x => x.Product.ModelName ?? "Product was deleted"))
                .ForMember(y => y.ProductCount, opt => opt.MapFrom(x => x.Count))
                .ForMember(y => y.ProductPropertyValueDTOs, opt => opt.MapFrom(x => x.ProductPropertyValues.Count));
        }
    }
}
