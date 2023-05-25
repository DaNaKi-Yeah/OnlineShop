using MediatR;

namespace OnlineShop.Application.CQRS.Values.Commands.CreateValue
{
    public class CreateValueCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
