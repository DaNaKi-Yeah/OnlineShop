using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventories
{
    public class GetProductPropertyValuesInventoriesQuery : IRequest<List<GetProductPropertyValuesInventoryDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
