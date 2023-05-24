using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class PropertyValuesConfiguration : IEntityTypeConfiguration<PropertyValue>
    {
        public void Configure(EntityTypeBuilder<PropertyValue> builder)
        {
            builder
                .HasOne(pv => pv.Property)
                .WithMany(p => p.PropertyValues)
                .HasForeignKey(pv => pv.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pv => pv.Value)
                .WithMany(v => v.PropertyValues)
                .HasForeignKey(pv => pv.ValueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(p => p.ProductPropertyValues)
               .WithOne(ppv => ppv.PropertyValue)
               .HasForeignKey(ppv => ppv.PropertyValueId)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
