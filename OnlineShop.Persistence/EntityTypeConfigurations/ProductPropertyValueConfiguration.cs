using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Relations;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class ProductPropertyValueConfiguration : IEntityTypeConfiguration<ProductPropertyValue>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyValue> builder)
        {
            builder
                .HasOne(ppv => ppv.PropertyValue)
                .WithMany(pv => pv.ProductPropertyValues)
                .HasForeignKey(pvv => pvv.PropertyValueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(ppv => ppv.ProductPropertyValuesInventory)
               .WithMany(ppvi => ppvi.ProductPropertyValues)
               .HasForeignKey(ppv => ppv.ProductPropertyValuesInventoryId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
