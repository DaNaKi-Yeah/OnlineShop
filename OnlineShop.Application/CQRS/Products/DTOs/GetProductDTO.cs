using AutoMapper;

using OnlineShop.Application.Common.Mappings;
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
    }
}
