using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Products.Commands.RemoveByIdProduct;
using OnlineShop.Application.CQRS.Products.Commands.UpdateProduct;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Products.Queries.GetProductById;
using OnlineShop.Application.CQRS.Products.Queries.SearchProducts;
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
        //TODO update Search with use multi filter
        [HttpGet]
        [Route("Search")]
        public async Task<List<GetProductDTO>> Search([FromQuery] SearchProductsQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
