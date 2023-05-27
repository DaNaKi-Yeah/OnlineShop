using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;
using System.Linq;

using OnlineShop.Application.CQRS.Reviews.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.CQRS.Properties.DTOs;

namespace OnlineShop.Application.CQRS.Reviews.Queries.SearchReviews
{
    public class SearchReviewsQueryHandler : ReviewHandler, IRequestHandler<SearchReviewsQuery, List<GetReviewDTO>>
    {
        public SearchReviewsQueryHandler(IRepository<Review, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetReviewDTO>> Handle(SearchReviewsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return _mapper.Map<List<GetReviewDTO>>(await _repository.GetAllAsync());
            }


            var baseResult = _mapper.Map<List<GetReviewDTO>>((await _repository.GetQuery().FirstOrDefaultAsync(x => x.ProductId == request.ProductId)).Product.Reviews.ToList());

            if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}