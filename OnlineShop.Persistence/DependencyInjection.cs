using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Persistence.Db.SqlServer;

namespace OnlineShop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SQLServerConnectionString");
            services.AddDbContext<SQLServerOnlineShopDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddScoped(typeof(IOnlineShopDbContext), typeof(SQLServerOnlineShopDbContext));


            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddDefaultTokenProviders()
                .AddUserManager<User>()
                .AddRoleManager<Role>()
                .AddEntityFrameworkStores<SQLServerOnlineShopDbContext>();

            return services;
        }

    }
}
