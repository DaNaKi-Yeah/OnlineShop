using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.BuyItems.Commands.UpdateBuyItem;
using OnlineShop.Application.CQRS.BuyItems.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BuyItems.Commands.RemoveBuyItemById
{
    public class RemoveBuyItemByIdCommandHandler : BuyItemHandler, IRequestHandler<RemoveBuyItemByIdCommand>
    {
        public RemoveBuyItemByIdCommandHandler(IRepository<BuyItem, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveBuyItemByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
