using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProducts
{
    public class SearchProductsQueryHandler : ProductHandler, IRequestHandler<SearchProductsQuery, List<SearchProductDTO>>
    {
        public SearchProductsQueryHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<SearchProductDTO>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                return _mapper.Map<List<SearchProductDTO>>(await _repository.GetAllAsync());
            }

            request.Search = request.Search.ToLower().Trim();

            var baseResult = _mapper.Map<List<SearchProductDTO>>(await _repository.GetQuery()
                    .Where(obj => obj.ModelName.ToLower().Contains(request.Search))
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
