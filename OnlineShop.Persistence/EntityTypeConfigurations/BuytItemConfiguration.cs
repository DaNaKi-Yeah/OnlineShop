using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Models;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class BuytItemConfiguration : IEntityTypeConfiguration<BuyItem>
    {
        public void Configure(EntityTypeBuilder<BuyItem> builder)
        {
            builder
                .HasOne(bi => bi.Product)
                .WithMany(p => p.BuyItems)
                .HasForeignKey(bi => bi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(bi => bi.Cart)
                .WithMany(c => c.BuyItems)
                .HasForeignKey(bi => bi.CartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
