﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Handlers;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.SearchProductPropertyValuesInventoriesByProductId
{
    public class SearchProductPropertyValuesInventoriesByProductIdQueryHandler : 
        ProductPropertyValuesInventoryHandler, 
        IRequestHandler<SearchProductPropertyValuesInventoriesByProductIdQuery, List<GetProductPropertyValuesInventoryDTO>>
    {
        public SearchProductPropertyValuesInventoriesByProductIdQueryHandler(IRepository<ProductPropertyValuesInventory, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetProductPropertyValuesInventoryDTO>> Handle(SearchProductPropertyValuesInventoriesByProductIdQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetQuery().Where(x => x.ProductId == request.ProductId).ToListAsync();

            var baseResult = _mapper.Map<List<GetProductPropertyValuesInventoryDTO>>(items);

            if (request.ProductId == 0)
            {
                return baseResult;
            }
            
            foreach (var item in items)
            {
                var dto = baseResult.First(x => x.Id == item.Id);

                dto.ProductName = item.Product.ModelName;
                dto.ProductCount = item.Count;
            }

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
