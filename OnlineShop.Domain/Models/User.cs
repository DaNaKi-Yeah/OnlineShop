﻿using Microsoft.AspNetCore.Identity;

using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class User:BaseEntity<int>
    {
        public string UserName { get; set; }
        public int? CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual List<BankAccount> BankAccounts { get; set; }
       
    }
}