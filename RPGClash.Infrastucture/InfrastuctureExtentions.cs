using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPGClash.Domain.Entities;
using RPGClash.Infrastucture.Repositories;

namespace RPGClash.Infrastucture
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("Reddis")));

            services.AddDbContext<GameDbContext>(builder =>
            {
                builder.UseSqlServer("Server = Database");
            });

            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),builder.Services);
            
            builder.AddEntityFrameworkStores<GameDbContext>();

            return services;
        }
    }
}
