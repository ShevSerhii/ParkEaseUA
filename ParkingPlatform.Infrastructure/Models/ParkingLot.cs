using System.ComponentModel.DataAnnotations;

namespace ParkingPlatform.Infrastructure.Models;

public class ParkingLot
{
    public int Id { get; set; }
        
    [Required]
    [StringLength(150)]
    public string Name { get; set; }
        
    [Required]
    [StringLength(250)]
    public string Address { get; set; }
        
    [Range(0, double.MaxValue)]
    public decimal PricePerHour { get; set; }
        
    [Range(0, int.MaxValue)]
    public int TotalSpots { get; set; }
        
    public ICollection<Reservation> Reservations { get; set; }
}