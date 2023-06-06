using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.CQRS.Payments.Queries.SearchPaymentsByUserId
{
    public class SearchPaymentsByUserIdQuery : IRequest<List<GetPaymentDTO>>
    {
        [Required]
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
