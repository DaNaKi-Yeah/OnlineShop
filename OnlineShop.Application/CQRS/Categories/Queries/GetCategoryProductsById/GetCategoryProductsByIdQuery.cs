using MediatR;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategoryProductsById
{
    public class GetCategoryProductsByIdQuery : IRequest<GetCategoryProductsDTO>
    {
        public int Id { get; set; }
    }
}
