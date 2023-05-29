﻿using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Categories.Queries.GetCategories;
using OnlineShop.Application.CQRS.Orders.Commands.CreateOrder;
using OnlineShop.Application.CQRS.Orders.Commands.RemoveByIdOrder;
using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Orders.Queries.GetOrderById;
using OnlineShop.Application.CQRS.Orders.Queries.GetOrders;

namespace OnlineShop.API.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task Remove([FromQuery] RemoveByIdOrderCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetOrderDTO> GetById([FromQuery] GetOrderByIdQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetOrderDTO>> Search([FromQuery] SearchOrdersQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}