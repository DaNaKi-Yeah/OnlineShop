using MediatR;
using OnlineShop.Application.CQRS.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.Users.Queries.GetUserByUserAccountId
{
    public class GetUserByUserAccountIdQuery : IRequest<GetUserDTO>
    {
        public int UserAccountId { get; set; }
    }
}
