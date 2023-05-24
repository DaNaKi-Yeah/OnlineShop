using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Repositories.Implementations;
using OnlineShop.Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

            return services;
        }
    }
}
