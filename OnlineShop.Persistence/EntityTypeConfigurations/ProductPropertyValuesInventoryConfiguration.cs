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
    public class ProductPropertyValuesInventoryConfiguration : IEntityTypeConfiguration<ProductPropertyValuesInventory>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyValuesInventory> builder)
        {
            builder
                .HasMany(ppvi => ppvi.ProductPropertyValues)
                .WithOne(pvv => pvv.ProductPropertyValuesInventory)
                .HasForeignKey(pvv => pvv.ProductPropertyValuesInventoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(ppvi => ppvi.Product)
               .WithMany(p => p.ProductPropertyValuesInventories)
               .HasForeignKey(ppvi => ppvi.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
