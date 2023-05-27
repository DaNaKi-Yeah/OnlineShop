using AutoMapper;

using OnlineShop.Application.Common;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Payments.Handlers
{
    public class PaymentHandler : BaseHandler<Payment, int>
    {
        public PaymentHandler(IRepository<Payment, int> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
