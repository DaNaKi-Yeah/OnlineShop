using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Handlers
{
    public class ProductPropertyValueHandler : BaseHandler<ProductPropertyValue, int>
    {
        public ProductPropertyValueHandler(IRepository<ProductPropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
