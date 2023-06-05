using AutoMapper;

using MediatR;

using OnlineShop.Application.CQRS.Orders.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : OrderHandler, IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IRepository<Cart, int> _cartRepository;
        private readonly IRepository<Payment, int> _paymentRepository;
        private readonly IRepository<BuyItem, int> _buyItemRepository;
        public CreateOrderCommandHandler
            (IRepository<Order, int> repository,
            IRepository<Cart, int> cartRepository,
            IRepository<Payment, int> paymentRepository,
            IRepository<BuyItem, int> buyItemRepository,
            IMapper mapper)
            : base(repository, mapper)
        {
            _cartRepository = cartRepository;
            _paymentRepository = paymentRepository;
            _buyItemRepository = buyItemRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var cartOut = await _cartRepository.GetByIdAsync(request.CartId);
            var buyItemIds = request.BuyItemIds;
            var bankAccountId = request.BankAccountId;


            var buyItems = new List<BuyItem>(); //

            foreach (var buyItem in cartOut.BuyItems)
            {
                if (buyItemIds.Contains(buyItem.Id))
                {
                    buyItems.Add(buyItem);
                }
            }


            var cart = new Cart() { UserId = userId };
            var cartId = await _cartRepository.AddAsync(cart);


            buyItems.ForEach(async x =>
            {
                x.CartId = cartId;
                await _buyItemRepository.UpdateAsync(x);
            });


            var payment = new Payment() { BankAccountId = bankAccountId };
            var paymentId = await _paymentRepository.AddAsync(payment);


            Order order = new Order();

            order.CartId = cartId;
            order.PaymentId = paymentId;

            var orderId = await _repository.AddAsync(order);


            payment = await _paymentRepository.GetByIdAsync(paymentId);
            payment.OrderId = orderId;
            await _paymentRepository.UpdateAsync(payment);


            return orderId;
        }
    }
}
