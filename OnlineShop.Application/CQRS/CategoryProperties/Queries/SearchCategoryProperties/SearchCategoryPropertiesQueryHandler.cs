using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using OnlineShop.Application.CQRS.CategoryProperties.Handlers;
using OnlineShop.Application.CQRS.CategoryProperties.Queries.GetCategoryPropertyById;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues;
using OnlineShop.Application.CQRS.Values.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.CategoryProperties.Queries.SearchCategoryProperties
{
    public class SearchCategoryPropertiesQueryHandler : CategoryPropertyHandler, IRequestHandler<SearchCategoryPropertiesQuery, List<GetCategoryPropertyDTO>>
    {
        public SearchCategoryPropertiesQueryHandler(IRepository<CategoryProperty, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetCategoryPropertyDTO>> Handle(SearchCategoryPropertiesQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                var allItems = await _repository.GetAllAsync();
                return _mapper.Map<List<GetCategoryPropertyDTO>>(allItems);
            }

            request.Search = request.Search.ToLower().Trim();


            List<CategoryProperty> categoryProperties = new List<CategoryProperty>();

            if (request.SearchCategoryPropertiesByName == SearchCategoryPropertiesByName.Category)
            {
                categoryProperties = await _repository.GetQuery()
                    .Where(obj => obj.Category.Name.ToLower().Contains(request.Search))
                    .ToListAsync();
            }
            else if (request.SearchCategoryPropertiesByName == SearchCategoryPropertiesByName.Property)
            {
                categoryProperties = await _repository.GetQuery()
                    .Where(obj => obj.Property.Name.ToLower().Contains(request.Search))
                    .ToListAsync();
            }


            var result = _mapper.Map<List<GetCategoryPropertyDTO>>(categoryProperties);

            if (request.PageSize == null || request.PageNumber == null)
            {
                return result;
            }

            return result
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
