using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Categories.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategory
{
    public class GetCategoryByIdQueryHandler : CategoryHandler, IRequestHandler<GetCategoryByIdQuery, GetCategoryDTO>
    {
        public GetCategoryByIdQueryHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetCategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetCategoryDTO>(category);
        }
    }
}
