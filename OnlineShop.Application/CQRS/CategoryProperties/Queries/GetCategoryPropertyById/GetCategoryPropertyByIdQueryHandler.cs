using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.CategoryProperties.Commands.CreateCategoryProperty;
using OnlineShop.Application.CQRS.CategoryProperties.Commands.RemoveByIdCategoryProperty;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using OnlineShop.Application.CQRS.CategoryProperties.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Queries.GetCategoryPropertyById
{
    public class GetCategoryPropertyByIdQueryHandler : CategoryPropertyHandler, IRequestHandler<GetCategoryPropertyByIdQuery, GetCategoryPropertyDTO>
    {
        public GetCategoryPropertyByIdQueryHandler(IRepository<CategoryProperty, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetCategoryPropertyDTO> Handle(GetCategoryPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<GetCategoryPropertyDTO>(await _repository.GetByIdAsync(request.Id));

            return result;
        }
    }
}
