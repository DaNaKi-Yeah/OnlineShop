using MediatR;

using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest, IMapWith<Product>
    {
        [Required]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int? YearOfProduction { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; }
        public decimal Price { get; set; }
    }
}
