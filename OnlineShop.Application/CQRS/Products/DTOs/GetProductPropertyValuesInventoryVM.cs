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

namespace OnlineShop.Application.CQRS.Products.DTOs
{
    public class GetProductPropertyValuesInventoryVM : IMapWith<ProductPropertyValuesInventory>
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int PropertyValuesCount { get; set; }
        public List<GetPropertyValueVM> PropertyValues { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPropertyValuesInventory, GetProductPropertyValuesInventoryVM>()
                .ForMember(y => y.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(y => y.ProductCount, opt => opt.MapFrom(x => x.Count))
                .ForMember(y => y.PropertyValuesCount, opt => opt.MapFrom(x => x.ProductPropertyValues.Count));
        }
    }
}
