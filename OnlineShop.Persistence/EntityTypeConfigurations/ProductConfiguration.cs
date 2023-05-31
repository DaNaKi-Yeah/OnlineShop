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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(p => p.ProductPropertyValuesInventories)
                .WithOne(ppvi => ppvi.Product)
                .HasForeignKey(ppvi => ppvi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(p => p.BuyItems)
                .WithOne(bi => bi.Product)
                .HasForeignKey(bi => bi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
