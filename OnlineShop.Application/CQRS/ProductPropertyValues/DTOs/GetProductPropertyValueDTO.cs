using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.ProductPropertyValues.Handlers;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.DTOs
{
    public class GetProductPropertyValueDTO : IMapWith<ProductPropertyValue>
    {
        public int Id { get; set; }
        public int PropertyValueId { get; set; }
        public string PropertyName { get; set; }
        public string ValueName { get; set; }
        public int ProductPropertyValuesInventoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPropertyValue, GetProductPropertyValueDTO>()
                .ForMember(gppv => gppv.Id, opt => opt.MapFrom(ppv => ppv.Id))
                .ForMember(gppv => gppv.PropertyValueId, opt => opt.MapFrom(ppv => ppv.PropertyValue.Id))
                .ForMember(gppv => gppv.PropertyName, opt => opt.MapFrom(ppv => ppv.PropertyValue.Property.Name ?? "Value was deleted"))
                .ForMember(gppv => gppv.ValueName, opt => opt.MapFrom(ppv => ppv.PropertyValue.Value.Name ?? "Property was deleted"))
                .ForMember(gppv => gppv.ProductPropertyValuesInventoryId, opt => opt.MapFrom(ppv => ppv.ProductPropertyValuesInventoryId));
        }
    }
}
