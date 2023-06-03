using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Models;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class BuyItemConfiguration : IEntityTypeConfiguration<BuyItem>
    {
        public void Configure(EntityTypeBuilder<BuyItem> builder)
        {

        }
    }
}
