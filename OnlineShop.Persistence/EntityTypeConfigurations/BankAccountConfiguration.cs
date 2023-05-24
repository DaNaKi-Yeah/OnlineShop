using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasOne(ba => ba.Client)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(ba => ba.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(ba => ba.Payments)
                .WithOne(p => p.BankAccount)
                .HasForeignKey(p => p.BankAccountId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
