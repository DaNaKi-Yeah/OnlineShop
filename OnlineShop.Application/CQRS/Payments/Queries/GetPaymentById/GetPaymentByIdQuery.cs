using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;

namespace OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<GetPaymentDTO>
    {
        public int Id { get; set; }
    }
}
