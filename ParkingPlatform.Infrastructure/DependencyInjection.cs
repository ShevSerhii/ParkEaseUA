using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingPlatform.Infrastructure.Models;

namespace ParkingPlatform.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext with PostgreSQL
            services.AddDbContext<ParkingPlatformDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("ParkingPlatformConnection")));

            // Register Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ParkingPlatformDbContext>()
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}