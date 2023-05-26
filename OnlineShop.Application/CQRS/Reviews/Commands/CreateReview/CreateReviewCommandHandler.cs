using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Reviews.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;



namespace OnlineShop.Application.CQRS.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : ReviewHandler, IRequestHandler<CreateReviewCommand, int>
    {
        public CreateReviewCommandHandler(IRepository<Review, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            Review review = new Review { Comment = request.Comment, Rating = request.Rating, ProductId = request.ProductId };

            int id = await _repository.AddAsync(review);

            return id;
        }
    }
}
