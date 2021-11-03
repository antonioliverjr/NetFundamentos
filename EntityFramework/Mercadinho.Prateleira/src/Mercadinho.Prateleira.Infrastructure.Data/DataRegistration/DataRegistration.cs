using Mercadinho.Prateleira.Infrastructure.Data.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.Infrastructure.Data.DataRegistration
{
    public static class DataRegistration
    {
        public static IServiceCollection AddDataRegistration(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DbContext, PrateleiraDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sql_connection"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
