using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.Carts.Commands.CreateCart;
using OnlineShop.Application.CQRS.Carts.Commands.RemoveCartById;
using OnlineShop.Application.CQRS.Carts.Commands.UpdateCart;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Application.CQRS.Carts.Queries.GetCarts;

namespace OnlineShop.API.Controllers
{
    public class CartController : BaseController
    {
        public CartController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        //[HttpPost]
        //[Route("Create")]
        //public async Task<int> Create([FromBody] CreateCartCommand command)
        //{
        //    var id = await _mediator.Send(command);

        //    return id;
        //}

        //[HttpPut]
        //[Route("Update")]
        //public async Task Update([FromBody] UpdateCartCommand command)
        //{
        //    await _mediator.Send(command);
        //}

        //[HttpDelete]
        //[Route("RemoveById")]
        //public async Task Remove([FromQuery] RemoveCartByIdCommand command)
        //{
        //    await _mediator.Send(command);
        //}

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<GetCartDTO>> GetAll([FromQuery] GetCartsQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
