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
               .HasMany(p => p.BuyItems)
               .WithOne(bi => bi.ProductPropertyValuesInventory)
               .HasForeignKey(bi => bi.ProductPropertyValuesInventoryId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
