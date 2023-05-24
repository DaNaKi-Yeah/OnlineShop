using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Interfaces;
using OnlineShop.Persistence.Db.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("SQLServerConnectionString");
            services.AddDbContext<SQLServerOnlineShopDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(IOnlineShopDbContext), typeof(SQLServerOnlineShopDbContext));

            return services;
        }
    }
}
