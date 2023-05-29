using System.ComponentModel.DataAnnotations;

using MediatR;

namespace OnlineShop.Application.CQRS.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<int>
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BankAccountId { get; set; }
    }
}
