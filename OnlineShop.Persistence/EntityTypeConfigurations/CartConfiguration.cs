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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
                .HasMany(c => c.BuyItems)
                .WithOne(bi => bi.Cart)
                .HasForeignKey(bi => bi.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Order)
                .WithOne(o => o.Cart)
                .HasForeignKey<Cart>(c => c.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
