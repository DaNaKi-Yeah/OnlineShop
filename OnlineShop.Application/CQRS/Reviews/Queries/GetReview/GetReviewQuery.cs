using MediatR;

using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.Queries.GetReview
{
    public class GetReviewQuery : IRequest<GetReviewDTO>
    {
        public int Id { get; set; }
    }
}
