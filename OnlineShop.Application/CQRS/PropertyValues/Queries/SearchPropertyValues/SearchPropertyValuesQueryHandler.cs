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

namespace OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues
{
    public class SearchPropertyValuesQueryHandler : PropertyValueHandler, IRequestHandler<SearchPropertyValuesQuery, List<GetPropertyValueDTO>>
    {
        public SearchPropertyValuesQueryHandler(IRepository<PropertyValue, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetPropertyValueDTO>> Handle(SearchPropertyValuesQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                var allItems = await _repository.GetAllAsync();
                return _mapper.Map<List<GetPropertyValueDTO>>(allItems);
            }

            request.Search = request.Search.ToLower().Trim();


            List<PropertyValue> propertyValues = new List<PropertyValue>();

            if (request.SearchPropertyValuesByName == SearchPropertyValuesByName.Property)
            {
                propertyValues = await _repository.GetQuery()
                    .Where(obj => obj.Property.Name.ToLower().Contains(request.Search))
                    .ToListAsync();
            }
            else if (request.SearchPropertyValuesByName == SearchPropertyValuesByName.Value)
            {
                propertyValues = await _repository.GetQuery()
                    .Where(obj => obj.Value.Name.ToLower().Contains(request.Search))
                    .ToListAsync();
            }


            var result = _mapper.Map<List<GetPropertyValueDTO>>(propertyValues);

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
