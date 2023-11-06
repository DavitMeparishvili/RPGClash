using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPGClash.Infrastucture.Repositories;

namespace RPGClash.Infrastucture
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("Reddis")));

            services.AddDbContextPool<GameDbContext>(builder =>
            {
                builder.UseSqlServer("Server = Database");
            });

            return services;
        }
    }
}
