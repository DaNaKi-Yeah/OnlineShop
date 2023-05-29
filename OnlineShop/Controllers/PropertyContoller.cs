using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;
using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.Commands.UpdateProperty;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.Properties.Queries.GetPropertyById;
using OnlineShop.Application.CQRS.Properties.Queries.SearchProperties;

namespace OnlineShop.API.Controllers
{
    public class PropertyController : BaseController
    {
        public PropertyController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreatePropertyCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpPut]
        [Route("Update")]
        public async Task Update([FromBody] UpdatePropertyCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task Remove([FromQuery] RemoveByIdPropertyCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetPropertyDTO> GetById([FromQuery] GetPropertyByIdQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetPropertyDTO>> Search([FromQuery] SearchPropertiesQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
