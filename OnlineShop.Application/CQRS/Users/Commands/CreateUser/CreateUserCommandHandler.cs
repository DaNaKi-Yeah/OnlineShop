using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : UserHandler, IRequestHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly IRepository<Cart, int> _cartRepository;
        public CreateUserCommandHandler(IRepository<User, int> repository, IRepository<Cart, int> cartRepository, IMapper mapper) : base(repository, mapper)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.AddAsync(new User() { UserName = request.UserName });

            var cartId = await _cartRepository.AddAsync(new Cart() { UserId = userId });

            var user = await _repository.GetByIdAsync(userId);

            user.CartId = cartId;

            await _repository.UpdateAsync(user);

            return new CreateUserDTO { UserId = userId, CartId = cartId };
        }
    }
}