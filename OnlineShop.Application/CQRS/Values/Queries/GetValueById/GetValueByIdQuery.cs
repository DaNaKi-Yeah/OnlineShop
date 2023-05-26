using MediatR;
using OnlineShop.Application.CQRS.Values.DTOs;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Queries.GetValue
{
    public class GetValueByIdQuery : IRequest<GetValueDTO>
    {
        public int Id { get; set; }
    }
}
