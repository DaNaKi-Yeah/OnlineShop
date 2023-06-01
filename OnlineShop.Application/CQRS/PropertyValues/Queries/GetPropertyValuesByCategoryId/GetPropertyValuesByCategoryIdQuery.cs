using MediatR;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValuesByCategoryId
{
    public class GetPropertyValuesByCategoryIdQuery : IRequest<List<GetPropertyValueDTO>>
    {
        [Required]
        public int CategoryId { get; set; }
    }
}
