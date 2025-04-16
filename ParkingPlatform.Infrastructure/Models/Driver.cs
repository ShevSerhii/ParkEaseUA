using System.ComponentModel.DataAnnotations;

namespace ParkingPlatform.Infrastructure.Models;

public class Driver
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string FullName { get; set; }
        
    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }
        
    [Phone]
    public string PhoneNumber { get; set; }
    
    public ICollection<Reservation> Reservations { get; set; }
}