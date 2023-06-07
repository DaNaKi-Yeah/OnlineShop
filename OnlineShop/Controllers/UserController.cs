using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.Users.Commands.CreateUser;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Queries.GetUsersByFullName;
using OnlineShop.Application.CQRS.Users.Queries.GetUserByUserAccountId;
using OnlineShop.Application.CQRS.Users.Queries.SearchUsers;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.Categories.DTOs;

namespace OnlineShop.API.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<CreateUserDTO>> Create([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<CreateUserDTO>(id, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetUserByUserAccountId")]
        public async Task<Response<GetUserDTO>> GetUserByUserAccountId([FromQuery] GetUserByUserAccountIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetUserDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetUsersByFullName")]
        public async Task<Response<List<GetUserDTO>>> GetUsersByFullName([FromQuery] GetUsersByFullNameQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetUserDTO>>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetAllWithPagination")]
        public async Task<Response<List<GetUserDTO>>> GetAllWithPagination([FromQuery] SearchUsersQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetUserDTO>>(result, 200, "Success", true);
        }
    }
}
