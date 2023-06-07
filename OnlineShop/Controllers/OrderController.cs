using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Orders.Commands.CreateOrder;
using OnlineShop.Application.CQRS.Orders.Commands.RemoveByIdOrder;
using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Orders.Queries.GetOrderById;
using OnlineShop.Application.CQRS.Orders.Queries.SearchOrdersByUserId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShop.API.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdOrderCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetOrderDTO>> GetById([FromQuery] GetOrderByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetOrderDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchByUserId")]
        public async Task<Response<List<GetOrderDTO>>> Search([FromQuery] SearchOrdersByUserIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetOrderDTO>>(result, 200, "Success", true);
        }
    }
}
