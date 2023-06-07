using Microsoft.AspNetCore.Identity;

using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Models
{
    public class User:BaseEntity<int>
    {
        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public string FirsName { get { return UserAccount.FirstName; } }
        public string LastName { get { return UserAccount.LastName; } }
        public int? CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual List<BankAccount> BankAccounts { get; set; }
       
    }
}