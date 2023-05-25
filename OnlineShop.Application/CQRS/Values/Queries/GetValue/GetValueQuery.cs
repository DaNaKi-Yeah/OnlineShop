using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Values.Queries.GetValue
{
    public class GetValueQuery : IRequest<Value>
    {
        public int Id { get; set; }
    }
}
