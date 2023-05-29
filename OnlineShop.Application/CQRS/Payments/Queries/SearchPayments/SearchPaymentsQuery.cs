using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;

namespace OnlineShop.Application.CQRS.Payments.Queries.SearchPayments
{
    public class SearchPaymentsQuery : IRequest<List<GetPaymentDTO>>
    {
        public int ClientId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
