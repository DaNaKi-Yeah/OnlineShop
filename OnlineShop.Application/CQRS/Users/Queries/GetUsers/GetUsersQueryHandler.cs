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

namespace OnlineShop.Application.CQRS.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : UserHandler, IRequestHandler<GetUsersQuery, List<GetUserDTO>>
    {
        public GetUsersQueryHandler(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetUserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync();

            return _mapper.Map<List<GetUserDTO>>(list);
        }
    }
}
