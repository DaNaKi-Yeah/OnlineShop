using MediatR;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Queries.SearchCategoryProperties
{
    public class SearchCategoryPropertiesQuery : IRequest<List<GetCategoryPropertyDTO>>
    {
        [Required]
        public SearchCategoryPropertiesByName SearchCategoryPropertiesByName { get; set; }
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
