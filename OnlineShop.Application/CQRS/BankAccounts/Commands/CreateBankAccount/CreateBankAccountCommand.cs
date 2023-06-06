using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.CreateBankAccount
{
    public class CreateBankAccountCommand : IRequest<int>
    {
        public int? UserId { get; set; }

        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public decimal Sum { get; set; }
    }
}
