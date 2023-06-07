using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Products.Commands.RemoveByIdProduct;
using OnlineShop.Application.CQRS.Products.Commands.UpdateProduct;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Queries.GetProductById;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsByCategoryId;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsByName;
using OnlineShop.Application.CQRS.Products.Queries.SearchProductsWithFilters;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShop.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Response<bool>> Update([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdProductCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetProductDTO>> GetById([FromQuery] GetProductByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetProductDTO>(result, 200, "Success", true);
        }
        
        [HttpGet]
        [Route("SearchProductsByCategoryId")]
        public async Task<Response<List<SearchProductDTO>>> SearchProductsByCategoryId([FromQuery] SearchProductsByCategoryIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<SearchProductDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchProductsByName")]
        public async Task<Response<List<SearchProductDTO>>> SearchProductsByName([FromQuery] SearchProductsByNameQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<SearchProductDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchProductsWithFilter")]
        public async Task<Response<List<SearchProductDTO>>> Search([FromQuery] SearchProductsWithFilterQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<SearchProductDTO>>(result, 200, "Success", true);
        }
    }
}
