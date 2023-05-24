using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Models;
using OnlineShop.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Db.SqlServer
{
    public class SQLServerOnlineShopDbContext : DbContext, IOnlineShopDbContext
    {
        public DbSet<BuyItem> BuyItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPropertyValuesInventory> ProductPropertyValuesInventories { get; set; }
        public DbSet<Property> PropertyValues { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Value> Values { get; set; }

        public SQLServerOnlineShopDbContext(DbContextOptions options) : base(options) { }

        private bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                IsSubclassOfRawGeneric(typeof(BaseEntity<>), i.GenericTypeArguments[0])));
        }
    }
}
