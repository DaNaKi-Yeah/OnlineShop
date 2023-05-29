using AutoMapper;

using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Handlers
{
    public class ProductHandler : BaseHandler<Product, int>
    {
        public ProductHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
