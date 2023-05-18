using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
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
        DbSet<Cart> Carts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductPropertyValuesInventory> ProductPropertyValuesInventories { get; set; }
        DbSet<Property> PropertyValues { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Value> Values { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
