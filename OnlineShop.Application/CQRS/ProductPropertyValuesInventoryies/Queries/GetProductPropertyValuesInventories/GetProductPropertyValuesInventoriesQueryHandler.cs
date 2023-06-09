﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Handlers;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventoryById;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventories
{
    public class GetProductPropertyValuesInventoriesQueryHandler :
        ProductPropertyValuesInventoryHandler,
        IRequestHandler<GetProductPropertyValuesInventoriesQuery, List<GetProductPropertyValuesInventoryDTO>>
    {
        public GetProductPropertyValuesInventoriesQueryHandler(IRepository<ProductPropertyValuesInventory, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetProductPropertyValuesInventoryDTO>> Handle(GetProductPropertyValuesInventoriesQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAllAsync();

            var baseResult = _mapper.Map<List<GetProductPropertyValuesInventoryDTO>>(items);

            foreach (var item in items)
            {
                var dto = baseResult.First(x => x.Id == item.Id);

                dto.ProductName = item.Product.ModelName;
                dto.ProductCount = item.Count;
            }

            if (request == null)
            {
                return baseResult;
            }
            else if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
