using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Payments.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : PaymentHandler, IRequestHandler<CreatePaymentCommand, int>
    {
        public CreatePaymentCommandHandler(IRepository<Payment, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment payment = new Payment { OrderId = request.OrderId, BankAccountId = request.BankAccountId };

            int id = await _repository.AddAsync(payment);

            return id;
        }
    }
}
