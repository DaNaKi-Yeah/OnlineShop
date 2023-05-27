using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Orders.Queries.GetOrderById;
using OnlineShop.Application.CQRS.Orders.Queries.SearchOrders;
using OnlineShop.Application.CQRS.Payments.Commands.RemoveByIdPayment;
using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById;
using OnlineShop.Application.CQRS.Payments.Queries.SearchPayments;
using OnlineShop.Application.CQRS.Properties.Commands.CreateProperty;
using OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty;
using OnlineShop.Application.CQRS.Properties.DTOs;
using OnlineShop.Application.CQRS.Properties.Queries.GetProperty;
using OnlineShop.Application.CQRS.Properties.Queries.SearchProperties;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

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

        [HttpDelete]
        [Route("Remove")]
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
