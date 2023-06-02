using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProductsByCategoryId
{
    public class SearchProductsByCategoryIdQueryHandler : ProductHandler, IRequestHandler<SearchProductsByCategoryIdQuery, List<SearchProductDTO>>
    {
        public SearchProductsByCategoryIdQueryHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<SearchProductDTO>> Handle(SearchProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.CategoryId == 0)
            {
                return _mapper.Map<List<SearchProductDTO>>(await _repository.GetAllAsync());
            }

            var baseResult = _mapper.Map<List<SearchProductDTO>>(await _repository.GetQuery()
                    .Where(obj => obj.CategoryId == request.CategoryId)
                    .ToListAsync());

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
