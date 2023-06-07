using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.CreateProductPropertyValuesInventory;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.RemoveProductPropertyValuesInventoryById;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.UpdateProductPropertyValues;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventories;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventoryById;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.SearchProductPropertyValuesInventoriesByProductId;
using OnlineShop.Application.CQRS.Products.DTOs;

namespace OnlineShop.API.Controllers
{
    public class ProductPropertyValuesInventoryController : BaseController
    {
        public ProductPropertyValuesInventoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateProductPropertyValuesInventoryCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveProductPropertyValuesInventoryByIdCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Response<bool>> Update([FromBody] UpdateProductPropertyValuesCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetProductPropertyValuesInventoryDTO>> GetById([FromQuery] GetProductPropertyValuesInventoryByIdCommand query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetProductPropertyValuesInventoryDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetAllWithPagination")]
        public async Task<Response<List<GetProductPropertyValuesInventoryDTO>>> GetAll([FromQuery] GetProductPropertyValuesInventoriesQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetProductPropertyValuesInventoryDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchByProductId")]
        public async Task<Response<List<GetProductPropertyValuesInventoryDTO>>> Search([FromQuery] SearchProductPropertyValuesInventoriesByProductIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetProductPropertyValuesInventoryDTO>>(result, 200, "Success", true);
        }
    }
}
