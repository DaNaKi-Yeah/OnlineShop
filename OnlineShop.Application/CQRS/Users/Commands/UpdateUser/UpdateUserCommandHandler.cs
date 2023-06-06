using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Users.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : UserHandler, IRequestHandler<UpdateUserCommand>
    {
        public UpdateUserCommandHandler(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            user.UserName = request.UserName;

            await _repository.UpdateAsync(user);
        }
    }
}
