using AutoMapper;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.DTOs
{
    public class GetProductDTO : IMapWith<Product>
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
        public string AverageRating { get; set; }

        public List<GetProductPropertyValuesInventoryVM> ProductPropertyValuesInventories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductDTO>()
                .ForMember(x => x.ModelName, opt => opt.MapFrom(y => y.ModelName))
                .ForMember(x => x.YearOfProduction, opt => opt.MapFrom(y => y.YearOfProduction))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.PictureLink, opt => opt.MapFrom(y => y.PictureLink))
                .ForMember(x => x.Price, opt => opt.MapFrom(y => y.Price))
                .ForMember(x => x.AverageRating, opt => opt.MapFrom(
                    y => y.Reviews.Count != 0
                        ? Math.Round((double)(y.Reviews.Select(r => r.Rating).Sum()) / (double)y.Reviews.Count, 1).ToString()
                        : "no reviews"));
        }
    }
}
