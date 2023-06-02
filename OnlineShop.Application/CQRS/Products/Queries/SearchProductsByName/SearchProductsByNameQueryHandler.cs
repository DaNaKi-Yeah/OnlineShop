using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Handlers;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsByCategoryId;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Products.Queries.SearchProductsByName
{
    public class SearchProductsByNameQueryHandler : ProductHandler, IRequestHandler<SearchProductsByNameQuery, List<SearchProductDTO>>
    {
        public SearchProductsByNameQueryHandler(IRepository<Product, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<SearchProductDTO>> Handle(SearchProductsByNameQuery request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                return _mapper.Map<List<SearchProductDTO>>(await _repository.GetAllAsync());
            }

            request.Search = request.Search.ToLower().Trim();

            var baseResult = _mapper.Map<List<SearchProductDTO>>(await _repository.GetQuery()
                    .Where(obj => obj.ModelName.ToLower().Contains(request.Search))
                    .ToListAsync());

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
