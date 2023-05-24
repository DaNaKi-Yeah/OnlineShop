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
    public class ValueConfiguration : IEntityTypeConfiguration<Value>
    {
        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder
                .HasMany(p => p.PropertyValues)
                .WithOne(pv => pv.Value)
                .HasForeignKey(pv => pv.ValueId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
