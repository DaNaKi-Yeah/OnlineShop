using MediatR;
using OnlineShop.Application.CQRS.BankAccounts.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.Queries.SearchBankAccountsByUserId
{
    public class SearchBankAccountsByUserIdQuery : IRequest<List<GetBankAccountDTO>>
    {
        [Required]
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
