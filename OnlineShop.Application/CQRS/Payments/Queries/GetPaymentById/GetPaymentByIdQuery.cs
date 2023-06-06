using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<GetPaymentDTO>
    {
        [Required]
        public int Id { get; set; }
    }
}
