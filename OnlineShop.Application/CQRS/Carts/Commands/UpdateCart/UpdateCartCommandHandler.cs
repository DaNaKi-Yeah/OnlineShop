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

namespace OnlineShop.Application.CQRS.Carts.Commands.UpdateCart
{
    public class UpdateCartCommandHandler : CartHandler, IRequestHandler<UpdateCartCommand>
    {
        public UpdateCartCommandHandler(IRepository<Cart, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(_mapper.Map<Cart>(request));
        }
    }
}
