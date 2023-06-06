using MediatR;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Queries.GetBankAccountById
{
    public class GetBankAccountByIdQuery : IRequest<GetBankAccountDTO>
    {
        public int Id { get; set; }
    }
}
