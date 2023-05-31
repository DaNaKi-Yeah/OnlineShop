using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using OnlineShop.Application.CQRS.Orders.DTOs;
using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Queries.SearchPayments
{
    public class SearchPaymentsQueryHandler : PaymentHandler, IRequestHandler<SearchPaymentsQuery, List<GetPaymentDTO>>
    {
        public SearchPaymentsQueryHandler(IRepository<Payment, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetPaymentDTO>> Handle(SearchPaymentsQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.ClientId == 0)
            {
                return _mapper.Map<List<GetPaymentDTO>>(await _repository.GetAllAsync());
            }


            var baseResult = _mapper.Map<List<GetPaymentDTO>>(await _repository.GetQuery().Where(x => x.Order.Cart.ClientId == request.ClientId)
                .ToListAsync());

            if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
