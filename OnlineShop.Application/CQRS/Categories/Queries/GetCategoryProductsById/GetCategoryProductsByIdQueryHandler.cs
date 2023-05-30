using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Categories.Handlers;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Categories.Queries.GetCategoryProductsById
{
    public class GetCategoryProductsByIdQueryHandler : CategoryHandler, IRequestHandler<GetCategoryProductsByIdQuery, GetCategoryProductsDTO>
    {
        public GetCategoryProductsByIdQueryHandler(IRepository<Category, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetCategoryProductsDTO> Handle(GetCategoryProductsByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetByIdAsync(request.Id);

            var getCategoryProductDTOs = _mapper.Map<List<SearchProductDTO>>(category.Products);

            var result = new GetCategoryProductsDTO() { Name = category.Name, Products = getCategoryProductDTOs };

            return result;
        }
    }
}
