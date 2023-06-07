using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Commands.CreateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.Commands.RemoveBuyItemById;
using OnlineShop.Application.CQRS.BuyItems.Commands.UpdateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Queries.GetBuyItemById;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItems;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId;
using OnlineShop.Application.CQRS.Products.DTOs;

namespace OnlineShop.API.Controllers
{
    public class BuyItemController : BaseController
    {
        public BuyItemController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
        //TODO throw new exep count BuyItem > Inventory.Count
        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateBuyItemCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Response<bool>> Update([FromBody] UpdateBuyItemCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveBuyItemByIdCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetBuyItemDTO>> GetById([FromQuery] GetBuyItemByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetBuyItemDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<Response<List<GetBuyItemDTO>>> Search([FromQuery] SearchBuyItemsQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetBuyItemDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchBuyItemsByUserId")]
        public async Task<Response<List<GetBuyItemDTO>>> SearchBuyItemsByUserId([FromQuery] SearchBuyItemsByUserIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetBuyItemDTO>>(result, 200, "Success", true);
        }
    }
}
