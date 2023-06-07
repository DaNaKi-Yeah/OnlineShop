using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Commands.RemoveBankAccountById
{
    public class RemoveBankAccountByIdCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
