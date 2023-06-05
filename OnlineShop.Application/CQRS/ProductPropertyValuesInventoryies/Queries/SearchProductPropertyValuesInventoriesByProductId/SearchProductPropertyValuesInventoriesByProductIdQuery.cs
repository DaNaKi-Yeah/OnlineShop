using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.SearchProductPropertyValuesInventoriesByProductId
{
    public class SearchProductPropertyValuesInventoriesByProductIdQuery : IRequest<List<GetProductPropertyValuesInventoryDTO>>
    {
        [Required]
        public int ProductId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
