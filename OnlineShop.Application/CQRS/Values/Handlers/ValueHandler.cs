using AutoMapper;

using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Handlers
{
    public class ValueHandler : BaseHandler<Value, int>
    {
        public ValueHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
