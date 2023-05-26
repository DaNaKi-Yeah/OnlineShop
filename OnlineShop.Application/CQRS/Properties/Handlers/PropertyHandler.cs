using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Handlers
{
    public class ReviewHandler : BaseHandler<Property, int>
    {
        public ReviewHandler(IRepository<Property, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
