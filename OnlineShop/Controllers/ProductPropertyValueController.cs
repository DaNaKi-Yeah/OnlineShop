using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.CQRS.ProductPropertyValues.Commands.CreateProductPropertyValue;
using OnlineShop.Application.CQRS.ProductPropertyValues.Commands.RemoveProductPropertyValueById;
using OnlineShop.Application.CQRS.ProductPropertyValues.DTOs;
using OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValueById;
using OnlineShop.Application.CQRS.ProductPropertyValues.Queries.GetProductPropertyValues;
using OnlineShop.Application.CQRS.PropertyValues.Commands.CreatePropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.Commands.RemoveByIdPropertyValue;
using OnlineShop.Application.CQRS.PropertyValues.DTOs;
using OnlineShop.Application.CQRS.PropertyValues.Queries.GetPropertyValueById;
using OnlineShop.Application.CQRS.PropertyValues.Queries.SearchPropertyValues;

namespace OnlineShop.API.Controllers
{
    public class ProductPropertyValueController : BaseController
    {
        public ProductPropertyValueController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] CreateProductPropertyValueCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        [HttpDelete]
        [Route("RemoveById")]
        public async Task Remove([FromQuery] RemoveProductPropertyValueByIdCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<GetProductPropertyValueDTO> GetById([FromQuery] GetProductPropertyValueByIdQuery query)
        {
            var result = await _mediator.Send(query);

            return result;
        }

        [HttpGet]
        [Route("GetAllWithPagination")]
        public async Task<List<GetProductPropertyValueDTO>> Search([FromQuery] GetProductPropertyValuesCommand query)
        {
            var result = await _mediator.Send(query);

            return result;
        }
    }
}
