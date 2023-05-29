using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Handlers
{
    public class PropertyValueHandler : BaseHandler<PropertyValue, int>
    {
        public PropertyValueHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
