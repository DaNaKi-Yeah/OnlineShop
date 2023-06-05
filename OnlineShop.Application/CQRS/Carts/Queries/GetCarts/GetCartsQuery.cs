using MediatR;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Queries.SearchCarts
{
    public class GetCartsQuery : IRequest<List<GetCartDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
