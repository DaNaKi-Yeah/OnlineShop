using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Reviews.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.Queries.GetReview
{
    public class GetReviewQueryHandler : ReviewHandler, IRequestHandler<GetReviewQuery, Review>
    {
        public GetReviewQueryHandler(IRepository<Review, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<Review> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            Review review = await _repository.GetByIdAsync(request.Id);

            return review;
        }
    }
}
