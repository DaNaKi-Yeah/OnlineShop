using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.CreateProductPropertyValuesInventory;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Commands.RemoveProductPropertyValuesInventoryById;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.GetProductPropertyValuesInventoryById;
using OnlineShop.Application.CQRS.ProductPropertyValuesInventoryies.Queries.SearchProductPropertyValuesInventories;

namespace OnlineShop.API.Controllers
{
    public class ProductPropertyValuesInventoryController : BaseController
    {
        public ProductPropertyValuesInventoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateProductPropertyValuesInventoryCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task Remove([FromQuery] RemoveProductPropertyValuesInventoryByIdCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetProductPropertyValuesInventoryDTO> GetById([FromQuery] GetProductPropertyValuesInventoryByIdCommand query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet]
        [Route("GetAllWithPagination")]
        public async Task<GetProductPropertyValuesInventoryDTO> GetAll([FromQuery] GetProductPropertyValuesInventoryByIdCommand query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetProductPropertyValuesInventoryDTO>> Search([FromQuery] SearchProductPropertyValuesInventoriesQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }
    }
}
