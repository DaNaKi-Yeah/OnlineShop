using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Carts.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Carts.Commands.RemoveCartById
{
    public class RemoveCartByIdCommandHandler : CartHandler, IRequestHandler<RemoveCartByIdCommand>
    {
        public RemoveCartByIdCommandHandler(IRepository<Cart, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(RemoveCartByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
        }
    }
}
