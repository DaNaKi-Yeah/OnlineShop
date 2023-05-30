﻿using AutoMapper;

using OnlineShop.Application.Common.Mappings;
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
        public string CategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductDTO>()
                .ForMember(x => x.ModelName, opt => opt.MapFrom(y => y.ModelName))
                .ForMember(x => x.YearOfProduction, opt => opt.MapFrom(y => y.YearOfProduction))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.PictureLink, opt => opt.MapFrom(y => y.PictureLink))
                .ForMember(x => x.Price, opt => opt.MapFrom(y => y.Price))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(y => y.Category.Name));
        }
    }
}
