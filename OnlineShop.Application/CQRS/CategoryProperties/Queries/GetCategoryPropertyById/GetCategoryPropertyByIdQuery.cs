using MediatR;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Queries.GetCategoryPropertyById
{
    public class GetCategoryPropertyByIdQuery: IRequest<GetCategoryPropertyDTO>
    {
        public int Id { get; set; }
    }
}
