using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.DTOs
{
    public class GetCategoryPropertyDTO : IMapWith<CategoryProperty>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string PropertyName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryProperty, GetCategoryPropertyDTO>()
                .ForMember(gpv => gpv.Id, opt => opt.MapFrom(pv => pv.Id))
                .ForMember(gpv => gpv.CategoryName, opt => opt.MapFrom(pv => pv.Category.Name))
                .ForMember(gpv => gpv.PropertyName, opt => opt.MapFrom(pv => pv.Property.Name));
        }
    }
}
