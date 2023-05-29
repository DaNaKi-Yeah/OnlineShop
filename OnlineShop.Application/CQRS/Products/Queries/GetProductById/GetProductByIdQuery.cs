using MediatR;

using OnlineShop.Application.CQRS.Products.DTOs;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductDTO>
    {
        public int Id { get; set; }
    }
}
