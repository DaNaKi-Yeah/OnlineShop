using AutoMapper;
using MediatR;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.CQRS.Properties.Commands.CreateProperty
{
    public class CreateProductCommand : IRequest<int>, IMapWith<Product>
    {
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int? CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductCommand, Product>()
                .ForMember(x => x.ModelName, opt => opt.MapFrom(y => y.ModelName))
                .ForMember(x => x.YearOfProduction, opt => opt.MapFrom(y => y.YearOfProduction))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.PictureLink, opt => opt.MapFrom(y => y.PictureLink))
                .ForMember(x => x.Price, opt => opt.MapFrom(y => y.Price))
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(y => y.CategoryId));
        }
    }
}
