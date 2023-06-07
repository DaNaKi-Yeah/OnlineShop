using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Responses;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using OnlineShop.Application.CQRS.Categories.Commands.CreateCategory;
using OnlineShop.Application.CQRS.Categories.Commands.RemoveByIdCategory;
using OnlineShop.Application.CQRS.Categories.DTOs;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategories;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategoryById;
using OnlineShop.Application.CQRS.Categories.Queries.GetCategoryProductsById;
using OnlineShop.Application.CQRS.Products.DTOs;
using OnlineShop.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShop.API.Controllers;
public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpPost]
    [Route("Create")]
    public async Task<Response<int>> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await _mediator.Send(command);

        return new Response<int>(id, 200, "Success", true);
    }

    [HttpDelete]
    [Route("RemoveById")]
    public async Task<Response<bool>> RemoveById([FromQuery] RemoveByIdCategoryCommand command)
    {
        await _mediator.Send(command);

        return new Response<bool>(true, 200, "Success", true);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<Response<GetCategoryDTO>> GetById([FromQuery] GetCategoryByIdQuery query)
    {
        var result = await _mediator.Send(query);

        return new Response<GetCategoryDTO>(result, 200, "Success", true);
    }

    [HttpGet]
    [Route("GetAllWithPagination")]
    public async Task<Response<List<GetCategoryDTO>>> GetAll([FromQuery] GetCategoriesQuery query)
    {
        var result = await _mediator.Send(query);

        return new Response<List<GetCategoryDTO>>(result, 200, "Success", true);
    }

    [HttpGet]
    [Route("GetCategoryProductsById")]
    public async Task<Response<GetCategoryProductsDTO>> GetCategoryProductsById([FromQuery] GetCategoryProductsByIdQuery query)
    {
        var result = await _mediator.Send(query);

        return new Response<GetCategoryProductsDTO>(result, 200, "Success", true);
    }
}

