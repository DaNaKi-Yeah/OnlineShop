using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.DTOs
{
    public class GetPropertyValueVM : IMapWith<ProductPropertyValue>
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string ValueName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPropertyValue, GetPropertyValueVM>()
                .ForMember(gppv => gppv.Id, opt => opt.MapFrom(ppv => ppv.Id))
                .ForMember(gppv => gppv.PropertyName, opt => opt.MapFrom(ppv => ppv.PropertyValue.Property.Name ?? "Value was deleted"))
                .ForMember(gppv => gppv.ValueName, opt => opt.MapFrom(ppv => ppv.PropertyValue.Value.Name ?? "Property was deleted"));
        }
    }
}
