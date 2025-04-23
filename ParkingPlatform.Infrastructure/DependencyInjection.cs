using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingPlatform.Application.Interfaces;
using ParkingPlatform.Infrastructure.Models;
using ParkingPlatform.Infrastructure.Services;

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

            // Register application services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}