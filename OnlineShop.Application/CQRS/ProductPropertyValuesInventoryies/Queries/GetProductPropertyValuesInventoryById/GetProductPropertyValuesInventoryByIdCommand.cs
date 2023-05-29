using MediatR;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventoryById
{
    public class GetProductPropertyValuesInventoryByIdCommand : IRequest<GetProductPropertyValuesInventoryDTO>
    {
        public int Id { get; set; }
    }
}
