using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Reviews.Commands.CreateReview;
using OnlineShop.Application.CQRS.Reviews.Commands.RemoveByIdReview;
using OnlineShop.Application.CQRS.Reviews.DTOs;
using OnlineShop.Application.CQRS.Reviews.Queries.GetReview;

namespace OnlineShop.API.Controllers
{
    public class ReviewController : BaseController
    {
        public ReviewController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateReviewCommand command)
        {
            var id = await _mediator.Send(command);

            return id;
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task Remove([FromQuery] RemoveByIdReviewCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetReviewDTO> GetById([FromQuery] GetReviewQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetReviewDTO>> Search([FromQuery] SearchReviewsQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
