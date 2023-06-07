using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValues.Commands.CreateProductPropertyValue;
using OnlineShop.Application.CQRS.ProductPropertyValues.Commands.RemoveProductPropertyValueById;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValueById;
using OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValues;
using OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.Commands.RemoveByIdPropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueById;
using OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues;

namespace OnlineShop.API.Controllers
{
    public class ProductPropertyValueController : BaseController
    {
        public ProductPropertyValueController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateProductPropertyValueCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveProductPropertyValueByIdCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetProductPropertyValueDTO>> GetById([FromQuery] GetProductPropertyValueByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetProductPropertyValueDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetAllWithPagination")]
        public async Task<Response<List<GetProductPropertyValueDTO>>> Search([FromQuery] GetProductPropertyValuesCommand query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetProductPropertyValueDTO>>(result, 200, "Success", true);
        }
    }
}
