using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Handlers
{
    public class OrderHandler : BaseHandler<Order, int>
    {
        public OrderHandler(IRepository<Order, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
