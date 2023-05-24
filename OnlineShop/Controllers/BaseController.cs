using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Repositories.Interfaces;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController: ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public BaseController(IMediator mediator, IMapper mapper) { _mediator = mediator; _mapper = mapper;}
    }
}
