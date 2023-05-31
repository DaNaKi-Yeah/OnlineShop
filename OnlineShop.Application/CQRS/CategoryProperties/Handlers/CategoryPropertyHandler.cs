using AutoMapper;
using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Handlers
{
    public class CategoryPropertyHandler : BaseHandler<CategoryProperty, int>
    {
        public CategoryPropertyHandler(IRepository<CategoryProperty, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
