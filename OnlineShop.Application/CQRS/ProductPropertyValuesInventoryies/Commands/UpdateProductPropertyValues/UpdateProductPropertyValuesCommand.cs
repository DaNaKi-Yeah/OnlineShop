using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.UpdateProductPropertyValues
{
    public class UpdateProductPropertyValuesCommand : IRequest
    {
        [Required]
        public int InventoryId { get; set; }
        public int Count { get; set; }
    }
}
