using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.CQRS.BankAccounts.DTOs
{
    public class GetBankAccountDTO : IMapWith<BankAccount>
    {
        public string CardNumber { get; set; }
        public decimal Sum { get; set; }
        public string CardDataHash { get; set; }

        public int UserId { get; set; }
    }
}
