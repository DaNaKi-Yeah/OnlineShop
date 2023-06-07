using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;
using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.Commands.UpdateProperty;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.Properties.Queries.GetPropertyById;
using OnlineShop.Application.CQRS.Properties.Queries.SearchProperties;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShop.API.Controllers
{
    public class PropertyController : BaseController
    {
        public PropertyController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreatePropertyCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Response<bool>> Update([FromBody] UpdatePropertyCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdPropertyCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetPropertyDTO>> GetById([FromQuery] GetPropertyByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetPropertyDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<Response<List<GetPropertyDTO>>> Search([FromQuery] SearchPropertiesQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetPropertyDTO>>(result, 200, "Success", true);
        }
    }
}
