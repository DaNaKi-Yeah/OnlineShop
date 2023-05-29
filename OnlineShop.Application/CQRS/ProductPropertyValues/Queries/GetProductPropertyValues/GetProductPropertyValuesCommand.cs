using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValues
{
    public class GetProductPropertyValuesCommand : IRequest<List<GetProductPropertyValueDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
