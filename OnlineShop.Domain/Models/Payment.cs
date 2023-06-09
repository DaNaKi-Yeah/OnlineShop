﻿using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class Payment: BaseEntity<int>
    {
        public decimal TotalSum { get { return Order.TotalSum; } }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int? BankAccountId { get; set; }
        public virtual BankAccount? BankAccount { get; set; }
    }
}
