using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Reviews.Commands.CreateReview;
using OnlineShop.Application.CQRS.Reviews.Commands.RemoveByIdReview;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.CQRS.Reviews.Queries.GetReview;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShop.API.Controllers
{
    public class ReviewController : BaseController
    {
        public ReviewController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateReviewCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdReviewCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetReviewDTO>> GetById([FromQuery] GetReviewQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetReviewDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<Response<List<GetReviewDTO>>> Search([FromQuery] SearchReviewsQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetReviewDTO>>(result, 200, "Success", true);
        }
    }
}
