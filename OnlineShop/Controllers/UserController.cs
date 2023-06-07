using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.Users.Commands.CreateUser;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Queries.GetUsersByFullName;
using OnlineShop.Application.CQRS.Users.Queries.GetUserByUserAccountId;
using OnlineShop.Application.CQRS.Users.Queries.SearchUsers;

namespace OnlineShop.API.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<CreateUserDTO> Create([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetUserByUserAccountId")]
        public async Task<GetUserDTO> GetUserByUserAccountId([FromQuery] GetUserByUserAccountIdQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("GetUsersByFullName")]
        public async Task<List<GetUserDTO>> GetUsersByFullName([FromQuery] GetUsersByFullNameQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("GetAllWithPagination")]
        public async Task<List<GetUserDTO>> GetAllWithPagination([FromQuery] SearchUsersQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
