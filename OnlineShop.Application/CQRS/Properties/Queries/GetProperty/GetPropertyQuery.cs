using MediatR;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Properties.Queries.GetProperty
{
    public class GetPropertyQuery : IRequest<Property>
    {
        public int Id { get; set; }
    }
}
