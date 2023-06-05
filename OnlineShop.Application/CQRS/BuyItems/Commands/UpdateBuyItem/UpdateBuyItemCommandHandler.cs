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

namespace OnlineShop.Application.CQRS.BuyItems.Commands.UpdateBuyItem
{
    public class UpdateBuyItemCommandHandler : BuyItemHandler, IRequestHandler<UpdateBuyItemCommand>
    {
        public UpdateBuyItemCommandHandler(IRepository<BuyItem, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateBuyItemCommand request, CancellationToken cancellationToken)
        {
            var buyItem = await _repository.GetByIdAsync(request.Id);

            var inventoryCount = buyItem.ProductPropertyValuesInventory.Count;

            if (request.Count > inventoryCount)
            {
                throw new ArgumentException("Count must be less than" + inventoryCount);
            }

            buyItem.Count = request.Count;

            await _repository.UpdateAsync(buyItem);
        }
    }
}
