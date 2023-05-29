using MediatR;

namespace OnlineShop.Application.CQRS.Products.Commands.RemoveByIdProduct
{
    public class RemoveByIdProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
