using MediatR;

namespace OnlineShop.Application.CQRS.Properties.Commands.CreateProperty
{
    public class CreateReviewCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
