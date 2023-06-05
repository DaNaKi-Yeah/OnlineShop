using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.Carts.Commands.CreateCart;
using OnlineShop.Application.CQRS.Carts.Commands.RemoveCartById;
using OnlineShop.Application.CQRS.Carts.Commands.UpdateCart;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Application.CQRS.Carts.Queries.SearchCarts;
using OnlineShop.Application.CQRS.Carts.Queries.SearchCartsByUserId;

namespace OnlineShop.API.Controllers
{
    public class CartController : BaseController
    {
        public CartController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
        //unnecessary endpoints
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
        //public async Task RemoveById([FromQuery] RemoveCartByIdCommand command)
        //{
        //    await _mediator.Send(command);
        //}

        [HttpGet]
        [Route("GetAllWitPagination")]
        public async Task<List<GetCartDTO>> GetAll([FromQuery] GetCartsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("SearchCartsByUserId")]
        public async Task<GetCartDTO> SearchCartsByUserId([FromQuery] GetCartByUserIdQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
