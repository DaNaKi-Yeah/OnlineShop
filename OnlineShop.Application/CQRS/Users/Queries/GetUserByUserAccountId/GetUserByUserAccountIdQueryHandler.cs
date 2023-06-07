using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Handlers;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Queries.GetUserByUserAccountId
{
    public class GetUserByUserAccountIdQueryHandler : UserHandler, IRequestHandler<GetUserByUserAccountIdQuery, GetUserDTO>
    {
        public GetUserByUserAccountIdQueryHandler(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetUserDTO> Handle(GetUserByUserAccountIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetQuery().FirstOrDefaultAsync(x => x.UserAccountId == request.UserAccountId);

            return _mapper.Map<GetUserDTO>(result);
        }
    }
}
