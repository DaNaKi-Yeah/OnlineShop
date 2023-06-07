using AutoMapper;
using MediatR;
using OnlineShop.Application.CQRS.Users.DTOs;
using OnlineShop.Application.CQRS.Users.Handlers;
using OnlineShop.Application.CQRS.Values.DTOs;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Queries.SearchUsers
{
    public class SearchUsersQueryHandler : UserHandler, IRequestHandler<SearchUsersQuery, List<GetUserDTO>>
    {
        public SearchUsersQueryHandler(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<List<GetUserDTO>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var allItems = _mapper.Map<List<GetUserDTO>>(await _repository.GetAllAsync());

            if (request == null)
            {
                return allItems;
            }

            if (request.PageSize == null || request.PageNumber == null)
            {
                return allItems;
            }

            return allItems
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}
