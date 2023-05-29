using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Categories.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : CategoryHandler, IRequestHandler<GetCategoriesQuery, List<GetCategoryDTO>>
    {
        public GetCategoriesQueryHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetCategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return _mapper.Map<List<GetCategoryDTO>>(await _repository.GetAllAsync());
            }

            var baseResult = _mapper.Map<List<GetCategoryDTO>>(await _repository.GetQuery()
                    .AsNoTracking()
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
