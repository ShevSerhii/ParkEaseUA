using System.ComponentModel.DataAnnotations;

namespace ParkingPlatform.Infrastructure.Models;

public class ParkingLot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal PricePerHour { get; set; }
    public int TotalSpots { get; set; }
        
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<ParkingSpot> ParkingSpots { get; set; }
}