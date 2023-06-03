using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Handlers
{
    public class CartHandler : BaseHandler<Cart, int>
    {
        public CartHandler(IRepository<Cart, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
