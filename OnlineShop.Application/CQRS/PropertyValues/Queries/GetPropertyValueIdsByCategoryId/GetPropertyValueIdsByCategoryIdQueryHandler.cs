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

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueIdsByCategoryId
{
    public class GetPropertyValueIdsByCategoryIdQueryHandler : PropertyValueHandler, IRequestHandler<GetPropertyValueIdsByCategoryIdQuery, List<int>>
    {
        public GetPropertyValueIdsByCategoryIdQueryHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<int>> Handle(GetPropertyValueIdsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var ids = await _repository.GetQuery().Where(x =>
                x.Property.CategoryProperties.FirstOrDefault(y => y.CategoryId == request.CategoryId).CategoryId == request.CategoryId)
                .Select(x => x.Id)
                .ToListAsync();

            return ids;
        }
    }
}
