using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Handlers
{
    public class CategoryHandler : BaseHandler<Category, int>
    {
        public CategoryHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
