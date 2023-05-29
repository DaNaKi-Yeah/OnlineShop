using MediatR;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Commands.CreateProductPropertyValue
{
    public class CreateProductPropertyValueCommand : IRequest<int>, IMapWith<ProductPropertyValue>
    {
        [Required]
        public int PropertyValueId { get; set; }
        [Required]
        public int ProductPropertyValuesInventoryId { get; set; }
    }
}
