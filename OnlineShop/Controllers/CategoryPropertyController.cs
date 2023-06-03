using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<int> Create([FromBody] CreateCategoryPropertyCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task Remove([FromQuery] RemoveByIdCategoryPropertyCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetCategoryPropertyDTO> GetById([FromQuery] GetCategoryPropertyByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<List<GetCategoryPropertyDTO>> Search([FromQuery] SearchCategoryPropertiesQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }
    }
}
