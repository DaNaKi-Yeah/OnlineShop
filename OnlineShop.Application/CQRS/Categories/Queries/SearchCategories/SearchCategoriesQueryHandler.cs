using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Properties.Queries.SearchProperties;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.SearchCategories
{
    public class SearchCategoriesQueryHandler : CategoryHandler, IRequestHandler<SearchCategoriesQuery, List<Category>>
    {
        public SearchCategoriesQueryHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<Category>> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                return await _repository.GetAllAsync();
            }

            request.Search = request.Search.ToLower().Trim();

            var baseResult = await _repository.GetQuery()
                    .AsNoTracking()
                    .Where(obj => obj.Name.ToLower().Contains(request.Search))
                    .ToListAsync();

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
