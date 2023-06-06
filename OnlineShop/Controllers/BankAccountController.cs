using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
using OnlineShop.Application.CQRS.Users.Commands.UpdateUser;

namespace OnlineShop.API.Controllers
{
    public class BankAccountController : BaseController
    {
        public BankAccountController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateBankAccountCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpPut]
        [Route("Update")]
        public async Task Update([FromBody] UpdateBankAccountCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task RemoveById([FromQuery] RemoveBankAccountByIdCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetBankAccountDTO> GetById([FromQuery] GetBankAccountByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("SearchBankAccountsByUserId")]
        public async Task<List<GetBankAccountDTO>> SearchBankAccountsByUserId([FromQuery] SearchBankAccountsByUserIdQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
