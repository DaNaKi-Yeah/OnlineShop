﻿using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Properties.Handlers;
using OnlineShop.Application.CQRS.Values.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Queries.SearchValues
{
    public class SearchValuesQueryHandler : ValueHandler, IRequestHandler<SearchValueQuery, List<Value>>
    {
        public SearchValuesQueryHandler(IRepository<Value, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<Value>> Handle(SearchValueQuery request, CancellationToken cancellationToken)
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