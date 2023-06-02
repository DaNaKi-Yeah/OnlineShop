using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Products.Commands.RemoveByIdProduct;
using OnlineShop.Application.CQRS.Products.Commands.UpdateProduct;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Queries.GetProductById;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsByCategoryId;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsByName;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsWithFilters;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;

namespace OnlineShop.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpPut]
        [Route("Update")]
        public async Task Update([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task Remove([FromQuery] RemoveByIdProductCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetProductDTO> GetById([FromQuery] GetProductByIdQuery command)
        {
            return await _mediator.Send(command);
        }
        
        [HttpGet]
        [Route("SearchProductsByCategoryId")]
        public async Task<List<SearchProductDTO>> SearchProductsByCategoryId([FromQuery] SearchProductsByCategoryIdQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("SearchProductsByName")]
        public async Task<List<SearchProductDTO>> SearchProductsByName([FromQuery] SearchProductsByNameQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("SearchProductsWithFilter")]
        public async Task<List<SearchProductDTO>> Search([FromQuery] SearchProductsWithFilterQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
