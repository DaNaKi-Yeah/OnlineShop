using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Commands.RemoveProductPropertyValueById
{
    public class RemoveProductPropertyValueByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
