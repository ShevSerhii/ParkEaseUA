using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ParkingPlatform.Infrastructure.Models;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ParkingPlatformDbContext>
{
    public ParkingPlatformDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ParkingPlatformDbContext>();

        optionsBuilder.UseNpgsql("Host=localhost;Database=parking_platform;Username=postgres;Password=12345678");

        return new ParkingPlatformDbContext(optionsBuilder.Options);
    }
}