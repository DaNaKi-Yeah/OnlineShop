using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.Commands.CreateBankAccount;
using OnlineShop.Application.CQRS.BankAccounts.Commands.RemoveBankAccountById;
using OnlineShop.Application.CQRS.BankAccounts.Commands.UpdateBankAccount;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.BankAccounts.Queries.GetBankAccountById;
using OnlineShop.Application.CQRS.BankAccounts.Queries.SearchBankAccountsByUserId;
using OnlineShop.Application.CQRS.BuyItems.Commands.CreateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.Commands.RemoveBuyItemById;
using OnlineShop.Application.CQRS.BuyItems.Commands.UpdateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.DTOs;
using OnlineShop.Application.CQRS.BuyItems.Queries.GetBuyItemById;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItems;
using OnlineShop.Application.CQRS.BuyItems.Queries.SearchBuyItemsByUserId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineShop.API.Controllers
{
    public class BankAccountController : BaseController
    {
        public BankAccountController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateBankAccountCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<Response<bool>> Update([FromBody] UpdateBankAccountCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveBankAccountByIdCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetBankAccountDTO>> GetById([FromQuery] GetBankAccountByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetBankAccountDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchBankAccountsByUserId")]
        public async Task<Response<List<GetBankAccountDTO>>> SearchBankAccountsByUserId([FromQuery] SearchBankAccountsByUserIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetBankAccountDTO>>(result, 200, "Success", true);
        }
    }
}
