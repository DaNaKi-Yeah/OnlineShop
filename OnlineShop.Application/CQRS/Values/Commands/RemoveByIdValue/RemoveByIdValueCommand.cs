using MediatR;

namespace OnlineShop.Application.CQRS.Values.Commands.RemoveByIdValue
{
    public class RemoveByIdValueCommand : IRequest
    {
        public int Id { get; set; }
    }
}
