using MediatR;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Queries.GetCarts
{
    public class GetCartsQuery : IRequest<List<GetCartDTO>>
    {
    }
}
