using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.DTOs
{
    public class GetPropertyValueDTO : IMapWith<PropertyValue>
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string ValueName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PropertyValue, GetPropertyValueDTO>()
                .ForMember(gpv => gpv.Id, opt => opt.MapFrom(pv => pv.Id))
                .ForMember(gpv => gpv.PropertyName, opt => opt.MapFrom(pv => pv.Property.Name ?? "Property was deleted"))
                .ForMember(gpv => gpv.ValueName, opt => opt.MapFrom(pv => pv.Value.Name ?? "Value was deleted"));
        }
    }
}
