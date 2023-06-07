using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Payments.Commands.CreatePayment;
using OnlineShop.Application.CQRS.Payments.Commands.RemoveByIdPayment;
using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById;
using OnlineShop.Application.CQRS.Payments.Queries.SearchPaymentsByUserId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShop.API.Controllers
{
    public class PaymentController : BaseController
    {
        public PaymentController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        //[HttpPost]
        //[Route("Create")]
        //public async Task<Response<int>> Create([FromBody] CreatePaymentCommand command)
        //{
        //    var id = await _mediator.Send(command);

        //    return id;
        //}

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdPaymentCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetPaymentDTO>> GetById([FromQuery] GetPaymentByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetPaymentDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("SearchByUserId")]
        public async Task<Response<List<GetPaymentDTO>>> Search([FromQuery] SearchPaymentsByUserIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetPaymentDTO>>(result, 200, "Success", true);
        }
    }
}
