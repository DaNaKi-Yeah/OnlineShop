using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Payments.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Commands.RemoveByIdPayment
{
    public class RemoveByIdPaymentCommandHandler : PaymentHandler, IRequestHandler<RemoveByIdPaymentCommand>
    {
        public RemoveByIdPaymentCommandHandler(IRepository<Payment, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveByIdPaymentCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
