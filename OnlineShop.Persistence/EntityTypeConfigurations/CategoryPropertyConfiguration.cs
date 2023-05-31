using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.EntityTypeConfigurations
{
    public class CategoryPropertyConfiguration : IEntityTypeConfiguration<CategoryProperty>
    {
        public void Configure(EntityTypeBuilder<CategoryProperty> builder)
        {
            builder
                .HasOne(x => x.Category)
                .WithMany(y => y.CategoryProperties)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Property)
                .WithMany(y => y.CategoryProperties)
                .HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
