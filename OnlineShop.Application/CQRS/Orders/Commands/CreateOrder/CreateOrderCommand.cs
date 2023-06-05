using MediatR;

using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public List<int> BuyItemIds { get; set; }
        public int BankAccountId { get; set; }
    }
}
