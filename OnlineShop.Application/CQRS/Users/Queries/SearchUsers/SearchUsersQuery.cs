using MediatR;
using OnlineShop.Application.CQRS.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Queries.SearchUsers
{
    public class SearchUsersQuery : IRequest<List<GetUserDTO>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
