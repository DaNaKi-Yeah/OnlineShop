using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Commands.RemoveByIdCategoryProperty
{
    public class RemoveByIdCategoryPropertyCommand : IRequest
    {
        public int Id { get; set; }
    }
}
