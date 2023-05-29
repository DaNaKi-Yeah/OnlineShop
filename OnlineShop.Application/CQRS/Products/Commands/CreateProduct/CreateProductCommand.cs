using MediatR;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Commands.CreateProperty
{
    public class CreateProductCommand : IRequest<int>, IMapWith<Product>
    {
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
    }
}
