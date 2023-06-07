using AutoMapper;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.DTOs
{
    public class SearchProductDTO : IMapWith<Product>
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
        public string AverageRating { get; set; } 
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, SearchProductDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.ModelName, opt => opt.MapFrom(y => y.ModelName))
                .ForMember(x => x.YearOfProduction, opt => opt.MapFrom(y => y.YearOfProduction))
                .ForMember(x => x.PictureLink, opt => opt.MapFrom(y => y.PictureLink))
                .ForMember(x => x.Price, opt => opt.MapFrom(y => y.Price))
                .ForMember(x => x.AverageRating, opt => opt.MapFrom(
                    y => y.Reviews.Count != 0
                        ? Math.Round((double)(y.Reviews.Select(r => r.Rating).Sum()) / (double)y.Reviews.Count, 1).ToString()
                        : "no reviews"));
        }
    }
}