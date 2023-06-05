using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Commands.RemoveCartById
{
    public class RemoveCartByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
