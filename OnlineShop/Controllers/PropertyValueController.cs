using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.Commands.RemoveByIdPropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueById;
using OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues;

namespace OnlineShop.API.Controllers
{
    public class PropertyValueController : BaseController
    {
        public PropertyValueController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<GetPropertyValueDTO> Create([FromBody] CreatePropertyValueCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task Remove([FromQuery] RemoveByIdPropertyValueCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetPropertyValueDTO> GetById([FromQuery] GetPropertyValueByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetPropertyValueDTO>> Search([FromQuery] SearchPropertyValuesQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }
    }
}
