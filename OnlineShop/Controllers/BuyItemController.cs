using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.BuyItems.Commands.CreateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.Commands.RemoveBuyItemById;
using OnlineShop.Application.CQRS.BuyItems.Commands.UpdateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Queries.GetBuyItemById;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItems;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId;

namespace OnlineShop.API.Controllers
{
    public class BuyItemController : BaseController
    {
        public BuyItemController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateBuyItemCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpPut]
        [Route("Update")]
        public async Task Update([FromBody] UpdateBuyItemCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task RemoveById([FromQuery] RemoveBuyItemByIdCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetBuyItemDTO> GetById([FromQuery] GetBuyItemByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetBuyItemDTO>> Search([FromQuery] SearchBuyItemsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("SearchBuyItemsByUserId")]
        public async Task<List<GetBuyItemDTO>> SearchBuyItemsByUserId([FromQuery] SearchBuyItemsByUserIdQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
