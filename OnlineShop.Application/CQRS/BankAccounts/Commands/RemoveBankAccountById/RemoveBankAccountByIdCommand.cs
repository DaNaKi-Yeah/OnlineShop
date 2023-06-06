using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.RemoveBankAccountById
{
    public class RemoveBankAccountByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
