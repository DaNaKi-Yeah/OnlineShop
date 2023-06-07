using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Handlers;
using OnlineShop.Application.CQRS.Users.Queries.GetUserByUserAccountId;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Queries.GetUsersByFullName
{
    public class GetUsersByFullNameQueryHandler : UserHandler, IRequestHandler<GetUsersByFullNameQuery, List<GetUserDTO>>
    {
        public GetUsersByFullNameQueryHandler(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetUserDTO>> Handle(GetUsersByFullNameQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            var result = users.Where(x => x.FirsName == request.FirstName && x.LastName == request.LastName).ToList();

            if (result.Count == 0)
            {
                result = users.Where(x => x.FirsName.Contains(request.FirstName ?? "")).ToList();

                if (result.Count == 0)
                {
                    result = users.Where(x => x.LastName.Contains(request.LastName ?? "")).ToList();

                    if (result.Count == 0)
                    {
                        throw new ArgumentException("Not found user with this FullName, FirstName, LastName");
                    }
                    return _mapper.Map<List<GetUserDTO>>(result);
                }
                return _mapper.Map<List<GetUserDTO>>(result);
            }

            return _mapper.Map<List<GetUserDTO>>(result);
        }
    }
}
