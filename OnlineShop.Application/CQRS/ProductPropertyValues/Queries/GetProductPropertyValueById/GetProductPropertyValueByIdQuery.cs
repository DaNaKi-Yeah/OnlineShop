using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValueById
{
    public class GetProductPropertyValueByIdQuery : IRequest<GetProductPropertyValueDTO>
    {
        public int Id { get; set; }
    }
}
