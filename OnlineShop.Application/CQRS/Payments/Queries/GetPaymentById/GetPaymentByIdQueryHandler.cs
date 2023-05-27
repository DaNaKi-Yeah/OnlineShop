using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Payments.DTOs;
using OnlineShop.Application.CQRS.Payments.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : PaymentHandler, IRequestHandler<GetPaymentByIdQuery, GetPaymentDTO>
    {
        public GetPaymentByIdQueryHandler(IRepository<Payment, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetPaymentDTO> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            Payment payment = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<GetPaymentDTO>(payment);
        }
    }
}
