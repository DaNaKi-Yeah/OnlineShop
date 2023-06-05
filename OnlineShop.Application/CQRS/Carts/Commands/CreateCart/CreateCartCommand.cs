using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<int>
    {
        public int UserId { get; set; }   
    }
}
