using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.BuyItems.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Commands.CreateBuyItem
{
    public class CreateBuyItemCommandHandler : BuyItemHandler, IRequestHandler<CreateBuyItemCommand, int>
    {
        private readonly IRepository<User, int> _userRepository;

        public CreateBuyItemCommandHandler
            (IRepository<BuyItem, int> repository,
            IRepository<User, int> userRepository,
            IMapper mapper) : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateBuyItemCommand request, CancellationToken cancellationToken)
        {
            var cartId = (await _userRepository.GetByIdAsync(request.UserId)).CartId;

            var buyItem = new BuyItem()
            {
                CartId = (int)cartId,
                ProductPropertyValuesInventoryId = request.InventoryId,
                Count = 1
            };

            var id = await _repository.AddAsync(buyItem);

            return id;
        }
    }
}
