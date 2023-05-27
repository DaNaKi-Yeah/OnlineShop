using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<int> Create([FromBody] CreateValueCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpPut]
        [Route("Update")]
        public async Task Update([FromBody] UpdateValueCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task Remove([FromQuery] RemoveByIdValueCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetValueDTO> GetById([FromQuery] GetValueByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetValueDTO>> Search([FromQuery] SearchValueQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
