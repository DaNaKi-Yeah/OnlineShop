using AutoMapper;

using MediatR;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : CategoryHandler, IRequestHandler<GetCategoryQuery, GetCategoryDTO>
    {
        public GetCategoryQueryHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetCategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetCategoryDTO>(category);
        }
    }
}
