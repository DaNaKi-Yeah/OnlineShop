using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.RemoveProductPropertyValuesInventoryById
{
    public class RemoveProductPropertyValuesInventoryByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
