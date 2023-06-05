using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.Users.Commands.CreateUser;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Queries.GetUsers;

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
        [Route("GetAll")]
        public async Task<List<GetUserDTO>> GetAll([FromQuery] GetUsersQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
