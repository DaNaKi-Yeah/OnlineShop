using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Commands.CreateCategoryProperty
{
    public class CreateCategoryPropertyCommand : IRequest<GetCategoryPropertyDTO>, IMapWith<CategoryProperty>
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int PropertyId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryPropertyCommand, CategoryProperty>()
                .ForMember(pv => pv.CategoryId, opt => opt.MapFrom(cpv => cpv.CategoryId))
                .ForMember(pv => pv.PropertyId, opt => opt.MapFrom(cpv => cpv.PropertyId));
        }
    }
}
