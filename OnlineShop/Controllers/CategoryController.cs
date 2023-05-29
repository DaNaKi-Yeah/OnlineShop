using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Categories.Commands.CreateCategory;
using OnlineShop.Application.CQRS.Categories.Commands.RemoveByIdCategory;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategory;
using OnlineShop.Application.CQRS.Categories.Queries.SearchCategories;

namespace OnlineShop.API.Controllers;
public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpPost]
    [Route("Create")]
    public async Task<int> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await _mediator.Send(command);

        return id;
    }

    [HttpDelete]
    [Route("Remove")]
    public async Task Remove([FromQuery] RemoveByIdCategoryCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<GetCategoryDTO> GetById([FromQuery] GetCategoryByIdQuery command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet]
    [Route("Search")]
    public async Task<List<GetCategoryDTO>> Search([FromQuery] GetCategoriesQuery query)
    {
        return await _mediator.Send(query);
    }
}

