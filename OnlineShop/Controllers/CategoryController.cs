using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.CQRS.Categories.Commands.CreateCategory;
using OnlineShop.Application.CQRS.Categories.Commands.RemoveByIdCategory;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategories;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategoryById;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategoryProductsById;

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
    [Route("RemoveById")]
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
    [Route("GetAllWithPagination")]
    public async Task<List<GetCategoryDTO>> GetAll([FromQuery] GetCategoriesQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpGet]
    [Route("GetCategoryProductsById")]
    public async Task<GetCategoryProductsDTO> GetCategoryProductsById([FromQuery] GetCategoryProductsByIdQuery query)
    {
        return await _mediator.Send(query);
    }
}

