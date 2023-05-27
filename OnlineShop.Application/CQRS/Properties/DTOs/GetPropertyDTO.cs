using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.DTOs
{
    public class GetPropertyDTO : IMapWith<Property>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, GetPropertyDTO>()
                .ForMember(gp => gp.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(gp => gp.Name, opt => opt.MapFrom(p => p.Name));
        }
    }
}
