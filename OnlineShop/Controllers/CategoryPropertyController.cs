using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.CategoryProperties.Commands.CreateCategoryProperty;
using OnlineShop.Application.CQRS.CategoryProperties.Commands.RemoveByIdCategoryProperty;
using OnlineShop.Application.CQRS.CategoryProperties.DTOs;
using OnlineShop.Application.CQRS.CategoryProperties.Queries.GetCategoryPropertyById;
using OnlineShop.Application.CQRS.CategoryProperties.Queries.SearchCategoryProperties;

namespace OnlineShop.API.Controllers
{
    public class CategoryPropertyController : BaseController
    {
        public CategoryPropertyController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<int>> Create([FromBody] CreateCategoryPropertyCommand command)
        {
            var id = await _mediator.Send(command);

            return new Response<int>(id, 200, "Success", true);
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdCategoryPropertyCommand command)
        {
            await _mediator.Send(command);

            return new Response<bool>(true, 200, "Success", true);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Response<GetCategoryPropertyDTO>> GetById([FromQuery] GetCategoryPropertyByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<GetCategoryPropertyDTO>(result, 200, "Success", true);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<Response<List<GetCategoryPropertyDTO>>> Search([FromQuery] SearchCategoryPropertiesQuery query)
        {
            var result = await _mediator.Send(query);

            return new Response<List<GetCategoryPropertyDTO>>(result, 200, "Success", true);
        }
    }
}
