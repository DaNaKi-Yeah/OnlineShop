using MediatR;
using OnlineShop.Application.CQRS.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Queries.GetUsersByFullName
{
    public class GetUsersByFullNameQuery : IRequest<List<GetUserDTO>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
