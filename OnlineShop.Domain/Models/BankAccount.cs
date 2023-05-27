﻿using OnlineShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Models
{
    public class BankAccount : BaseEntity<int>
    {
        public string CardNumber { get; set; }
        public decimal Sum { get; set; }
        public string CardDataHash { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
}
