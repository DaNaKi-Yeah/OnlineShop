using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Reviews.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Reviews.Commands.RemoveByIdReview
{
    public class RemoveByIdReviewCommandHandler : ReviewHandler, IRequestHandler<RemoveByIdReviewCommand>
    {
        public RemoveByIdReviewCommandHandler(IRepository<Review, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
