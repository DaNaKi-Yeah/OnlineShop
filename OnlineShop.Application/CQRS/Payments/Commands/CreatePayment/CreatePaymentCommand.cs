using MediatR;

namespace OnlineShop.Application.CQRS.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public int? BankAccountId { get; set; }
    }
}
