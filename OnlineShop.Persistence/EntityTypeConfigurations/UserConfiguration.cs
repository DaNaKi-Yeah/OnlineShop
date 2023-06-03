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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(c => c.Cart)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(c => c.BankAccounts)
                .WithOne(ba => ba.User)
                .HasForeignKey(ba => ba.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
