using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Commands.RemoveByIdPropertyValue
{
    public class RemoveByIdPropertyValueCommand: IRequest
    {
        public int Id { get; set; }
    }
}
