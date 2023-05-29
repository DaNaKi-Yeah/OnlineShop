using MediatR;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues
{
    public class SearchPropertyValuesQuery : IRequest<List<GetPropertyValueDTO>>
    {
        [Required]
        public SearchPropertyValuesByName SearchPropertyValuesByName { get; set; }
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
