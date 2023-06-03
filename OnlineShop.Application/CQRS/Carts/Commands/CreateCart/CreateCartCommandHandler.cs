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

namespace OnlineShop.Application.CQRS.Carts.Commands.CreateCart
{
    public class CreateCartCommandHandler : CartHandler, IRequestHandler<CreateCartCommand, int>
    {
        public CreateCartCommandHandler(IRepository<Cart, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var id = await _repository.AddAsync(new Cart());

            return id;
        }
    }
}
