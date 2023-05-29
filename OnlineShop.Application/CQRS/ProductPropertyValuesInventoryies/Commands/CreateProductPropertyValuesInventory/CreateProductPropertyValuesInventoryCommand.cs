using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.CreateProductPropertyValuesInventory
{
    public class CreateProductPropertyValuesInventoryCommand : IRequest<int>
    {
        [Required]
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
