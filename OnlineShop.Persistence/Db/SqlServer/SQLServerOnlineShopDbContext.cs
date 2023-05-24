using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new BuytItemConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPropertyValueConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPropertyValuesInventoryConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyValuesConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ValueConfiguration());
        }
    }
}
