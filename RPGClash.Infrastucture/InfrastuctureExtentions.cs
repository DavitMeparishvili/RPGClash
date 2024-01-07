using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPGClash.Domain.Entities;
using RPGClash.Domain.Repositories;
using RPGClash.Infrastucture.Repositories;

namespace RPGClash.Infrastucture
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration.GetConnectionString("GameDb");

            services.AddDbContext<GameDbContext>(builder =>
            {
                builder.UseSqlServer(conectionString);
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

            services.AddScoped<IGameStateRepo, GameStateRepo>();

            return services;
        }
    }
}
