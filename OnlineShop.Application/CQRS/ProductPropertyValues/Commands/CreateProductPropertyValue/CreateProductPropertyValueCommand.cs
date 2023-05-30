using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Commands.CreateProductPropertyValue
{
    public class CreateProductPropertyValueCommand : IRequest<int>, IMapWith<ProductPropertyValue>
    {
        [Required]
        public int? PropertyValueId { get; set; }
        [Required]
        public int ProductPropertyValuesInventoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductPropertyValueCommand, ProductPropertyValue>()
                .ForMember(x => x.PropertyValueId, opt => opt.MapFrom(y => y.PropertyValueId))
                .ForMember(x => x.ProductPropertyValuesInventoryId, opt => opt.MapFrom(y => y.ProductPropertyValuesInventoryId));
        }
    }
}
