using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

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
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                return _mapper.Map<List<GetPaymentDTO>>(await _repository.GetAllAsync());
            }

            request.Search = request.Search.ToLower().Trim();
            
            var baseResult = _mapper.Map<List<GetPaymentDTO>>(await _repository.GetQuery()
                    .AsNoTracking()
                    .Where(obj => obj.Name.ToLower().Contains(request.Search))
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
