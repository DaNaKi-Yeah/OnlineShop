using MediatR;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueById
{
    public class GetPropertyValueByIdQuery : IRequest<GetPropertyValueDTO>
    {
        public int Id { get; set; }
    }
}
