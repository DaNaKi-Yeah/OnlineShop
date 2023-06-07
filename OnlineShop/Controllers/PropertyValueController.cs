using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.Commands.RemoveByIdPropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueById;
using OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueIdsByCategoryId;
using OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValuesByCategoryId;
using OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues;

namespace OnlineShop.API.Controllers
{
    public class PropertyValueController : BaseController
    {
        public PropertyValueController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreatePropertyValueCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdPropertyValueCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetPropertyValueDTO>> GetById([FromQuery] GetPropertyValueByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetPropertyValueDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetPropertyValuesByCategoryId")]
        public async Task<Response<List<GetPropertyValueDTO>>> GetPropertyValuesByCategoryId([FromQuery] GetPropertyValuesByCategoryIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetPropertyValueDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetPropertyValueIdsByCategoryId")]
        public async Task<Response<List<int>>> GetPropertyValueIdsByCategoryId([FromQuery] GetPropertyValueIdsByCategoryIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<int>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<Response<List<GetPropertyValueDTO>>> Search([FromQuery] SearchPropertyValuesQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetPropertyValueDTO>>(result, 200, "Success", true);
        }
    }
}
