using MediatR;

namespace OnlineShop.Application.CQRS.Properties.Commands.CreateProperty
{
    public class CreatePropertyCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
