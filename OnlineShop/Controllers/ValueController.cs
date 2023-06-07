using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Application.CQRS.Properties.Commands.UpdateProperty;
using OnlineShop.Application.CQRS.Values.Commands.CreateValue;
using OnlineShop.Application.CQRS.Values.Commands.RemoveByIdValue;
using OnlineShop.Application.CQRS.Values.Commands.UpdateValue;
using OnlineShop.Application.CQRS.Values.DTOs;
using OnlineShop.Application.CQRS.Values.Queries.GetValue;
using OnlineShop.Application.CQRS.Values.Queries.SearchValues;

namespace OnlineShop.API.Controllers
{
    public class ValueController : BaseController
    {
        public ValueController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }


        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateValueCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Response<bool>> Update([FromBody] UpdateValueCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdValueCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetValueDTO>> GetById([FromQuery] GetValueByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetValueDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<Response<List<GetValueDTO>>> Search([FromQuery] SearchValueQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetValueDTO>>(result, 200, "Success", true);
        }
    }
}
