using MediatR;

namespace OnlineShop.Application.CQRS.Reviews.Commands.RemoveByIdReview
{
    public class RemoveByIdReviewCommand : IRequest
    {
        public int Id { get; set; }
    }
}
