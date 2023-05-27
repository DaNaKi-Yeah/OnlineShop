using MediatR;

namespace OnlineShop.Application.CQRS.Payments.Commands.RemoveByIdPayment
{
    public class RemoveByIdPaymentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
