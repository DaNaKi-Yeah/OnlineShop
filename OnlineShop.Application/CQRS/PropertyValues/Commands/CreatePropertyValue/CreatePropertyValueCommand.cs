using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue
{
    public class CreatePropertyValueCommand : IRequest<int>, IMapWith<PropertyValue>
    {
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public int ValueId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePropertyValueCommand, PropertyValue>()
                .ForMember(pv => pv.PropertyId, opt => opt.MapFrom(cpv => cpv.PropertyId))
                .ForMember(pv => pv.ValueId, opt => opt.MapFrom(cpv => cpv.ValueId));
        }
    }
}
