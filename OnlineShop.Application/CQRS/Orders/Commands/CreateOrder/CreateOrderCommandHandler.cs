using AutoMapper;

using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.Orders.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : OrderHandler, IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IRepository<BankAccount, int> _bankAccountRepository;
        private readonly IRepository<ProductPropertyValuesInventory, int> _inventoryRepository;
        private readonly IRepository<Cart, int> _cartRepository;
        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Payment, int> _paymentRepository;
        private readonly IRepository<BuyItem, int> _buyItemRepository;
        public CreateOrderCommandHandler
            (IRepository<Order, int> repository,
            IRepository<BankAccount, int> bankAccountRepository,
            IRepository<ProductPropertyValuesInventory, int> inventoryRepository,
            IRepository<Cart, int> cartRepository,
            IRepository<User, int> userRepository,
            IRepository<Payment, int> paymentRepository,
            IRepository<BuyItem, int> buyItemRepository,
            IMapper mapper)
            : base(repository, mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _inventoryRepository = inventoryRepository;
            _cartRepository = cartRepository;
            _paymentRepository = paymentRepository;
            _buyItemRepository = buyItemRepository;
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var cartOut = await _cartRepository.GetByIdAsync((int)(await _userRepository.GetByIdAsync(request.UserId)).CartId);
            var buyItemIds = request.BuyItemIds;
            var bankAccountId = request.BankAccountId;
            var bankAccount = await _bankAccountRepository.GetByIdAsync(bankAccountId);

            var buyItems = new List<BuyItem>();

            foreach (var buyItem in cartOut.BuyItems)
            {
                if (buyItemIds.Contains(buyItem.Id))
                {
                    buyItems.Add(buyItem);
                }
            }

            var sumForPay = buyItems.Sum(x => x.Count * x.ProductPropertyValuesInventory.Product.Price);

            var baSum = bankAccount.Sum;

            if (baSum < sumForPay)
            {
                throw new Exception($"BankAccount have {baSum} money, sum for pay need {sumForPay}");
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


            bankAccount.Sum -= sumForPay;
            await _bankAccountRepository.UpdateAsync(bankAccount);

            var inventories = await _inventoryRepository.GetQuery().Where(x => buyItems.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            foreach (var inventory in inventories)
            {
                inventory.Count -= buyItems.First(x => x.ProductPropertyValuesInventoryId == inventory.Id).Count;
                await _inventoryRepository.UpdateAsync(inventory);
            }

            return orderId;
        }
    }
}
