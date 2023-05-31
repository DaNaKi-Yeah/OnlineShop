using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.DTOs
{
    public class SearchProductDTO : IMapWith<Product>
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
        //TODO average rating
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, SearchProductDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.ModelName, opt => opt.MapFrom(y => y.ModelName))
                .ForMember(x => x.PictureLink, opt => opt.MapFrom(y => y.PictureLink))
                .ForMember(x => x.Price, opt => opt.MapFrom(y => y.Price));
        }
    }
}