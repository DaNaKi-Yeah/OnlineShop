using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IOnlineShopDbContext
    {
        DbSet<BuyItem> BuyItems { get; set; }
        DbSet<CategoryProperty> CategoryProperties { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductPropertyValuesInventory> ProductPropertyValuesInventories { get; set; }
        DbSet<PropertyValue> PropertyValues { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Value> Values { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<BankAccount> BankAccounts { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
