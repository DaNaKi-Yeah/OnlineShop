using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.DTOs
{
    public class GetUserDTO : IMapWith<User>
    {
        public int Id { get; set; }
        public int? CartId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.CartId, opt => opt.MapFrom(y => y.CartId));
        }
    }
}
