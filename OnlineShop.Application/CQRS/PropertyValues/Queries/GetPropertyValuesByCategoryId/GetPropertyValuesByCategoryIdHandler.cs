using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValuesByCategoryId
{
    public class GetPropertyValuesByCategoryIdHandler : PropertyValueHandler, IRequestHandler<GetPropertyValuesByCategoryIdQuery, List<GetPropertyValueDTO>>
    {
        public GetPropertyValuesByCategoryIdHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetPropertyValueDTO>> Handle(GetPropertyValuesByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetQuery().Where(x => 
                x.Property.CategoryProperties.FirstOrDefault(y => y.CategoryId == request.CategoryId).CategoryId == request.CategoryId)
                .ToListAsync();

            return _mapper.Map<List<GetPropertyValueDTO>>(result);
        }
    }
}
