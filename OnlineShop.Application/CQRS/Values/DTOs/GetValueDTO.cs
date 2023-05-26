using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Values.DTOs
{
    public class GetValueDTO: IMapWith<Value>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Value, GetValueDTO>()
                .ForMember(gv => gv.Id, opt => opt.MapFrom(v => v.Id))
                .ForMember(gv => gv.Name, opt => opt.MapFrom(v => v.Name));
        }
    }
}
