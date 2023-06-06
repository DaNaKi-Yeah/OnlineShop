using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.UpdateBankAccount
{
    public class UpdateBankAccountCommand : IRequest
    {
        public int Id { get; set; }
        public decimal AddSum { get; set; }
    }
}
