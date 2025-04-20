using Microsoft.EntityFrameworkCore;
using ParkingPlatform.Infrastructure.Models;

namespace ParkingPlatform.Infrastructure
{
    public class ParkingPlatformDbContext : DbContext
    {
        public ParkingPlatformDbContext(DbContextOptions<ParkingPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.Reservations)
                .WithOne(r => r.Driver)
                .HasForeignKey(r => r.DriverId);

            modelBuilder.Entity<ParkingLot>()
                .HasMany(p => p.Reservations)
                .WithOne(r => r.ParkingLot)
                .HasForeignKey(r => r.ParkingLotId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Reservations)
                .HasForeignKey(r => r.DriverId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ParkingLot)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.ParkingLotId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithOne(r => r.Payment)
                .HasForeignKey<Payment>(p => p.ReservationId);
            
            modelBuilder.Entity<ParkingLot>()
                .HasMany(p => p.ParkingSpots)
                .WithOne(s => s.ParkingLot)
                .HasForeignKey(s => s.ParkingLotId);
        }
    }
}