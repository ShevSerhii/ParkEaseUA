using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingPlatform.Infrastructure.Models;

public class Notification
{
    public int Id { get; set; }
        
    [Required]
    [StringLength(500)]
    public string Message { get; set; }
        
    public DateTime Date { get; set; }
        
    [ForeignKey("Driver")]
    public int DriverId { get; set; }
        
    public bool IsRead { get; set; }

    public Driver Driver { get; set; }
}