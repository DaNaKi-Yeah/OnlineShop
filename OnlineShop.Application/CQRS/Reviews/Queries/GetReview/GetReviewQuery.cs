using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.Queries.GetReview
{
    public class GetReviewQuery : IRequest<Review>
    {
        public int Id { get; set; }
    }
}
