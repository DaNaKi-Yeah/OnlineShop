using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Categories.DTOs
{
    public class GetCategoryDTO : IMapWith<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryDTO>()
                .ForMember(gc => gc.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(gc => gc.Name, opt => opt.MapFrom(c => c.Name));
        }
    }
}
