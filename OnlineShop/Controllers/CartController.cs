using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.Carts.Commands.CreateCart;
using OnlineShop.Application.CQRS.Carts.Commands.RemoveCartById;
using OnlineShop.Application.CQRS.Carts.Commands.UpdateCart;
using OnlineShop.Application.CQRS.Carts.DTOs;
using OnlineShop.Application.CQRS.Carts.Queries.SearchCarts;
using OnlineShop.Application.CQRS.Carts.Queries.SearchCartsByUserId;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Products.DTOs;

namespace OnlineShop.API.Controllers
{
    public class CartController : BaseController
    {
        public CartController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
        //unnecessary endpoints
        //[HttpPost]
        //[Route("Create")]
        //public async Task<Response<int>> Create([FromBody] CreateCartCommand command)
        //{
        //    var id = await _mediator.Send(command);

        //    return id;
        //}

        //[HttpPut]
        //[Route("Update")]
        //public async Task<Response<bool>> Update([FromBody] UpdateCartCommand command)
        //{
        //    await _mediator.Send(command);

            //return new Response<bool>(true, 200, "Success", true);
        //}

        //[HttpDelete]
        //[Route("RemoveById")]
        //public async Task<Response<bool>> RemoveById([FromQuery] RemoveCartByIdCommand command)
        //{
        //    await _mediator.Send(command);

            //return new Response<bool>(true, 200, "Success", true);
        //}

        [HttpGet]
        [Route("GetAllWitPagination")]
        public async Task<Response<List<GetCartDTO>>> GetAll([FromQuery] GetCartsQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetCartDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetCartByUserId")]
        public async Task<Response<GetCartDTO>> GetCartByUserId([FromQuery] GetCartByUserIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetCartDTO>(result, 200, "Success", true);
        }
    }
}
