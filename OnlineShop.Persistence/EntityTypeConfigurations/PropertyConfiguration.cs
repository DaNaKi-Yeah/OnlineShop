using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Models;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder
                .HasMany(p => p.PropertyValues)
                .WithOne(pv => pv.Property)
                .HasForeignKey(pv => pv.PropertyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
