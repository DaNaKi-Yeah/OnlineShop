using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Payments.Commands.CreatePayment;
using OnlineShop.Application.CQRS.Payments.Commands.RemoveByIdPayment;
using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById;
using OnlineShop.Application.CQRS.Payments.Queries.SearchPaymentsByUserId;

namespace OnlineShop.API.Controllers
{
    public class PaymentController : BaseController
    {
        public PaymentController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        //[HttpPost]
        //[Route("Create")]
        //public async Task<int> Create([FromBody] CreatePaymentCommand command)
        //{
        //    var id = await _mediator.Send(command);

        //    return id;
        //}

        [HttpDelete]
        [Route("RemoveById")]
        public async Task RemoveById([FromQuery] RemoveByIdPaymentCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetPaymentDTO> GetById([FromQuery] GetPaymentByIdQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("SearchByUserId")]
        public async Task<List<GetPaymentDTO>> Search([FromQuery] SearchPaymentsByUserIdQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
