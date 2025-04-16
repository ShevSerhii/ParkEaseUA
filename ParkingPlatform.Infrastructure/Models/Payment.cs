using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingPlatform.Infrastructure.Models;

public class Payment
{
    public int Id { get; set; }
        
    [ForeignKey("Reservation")]
    public int ReservationId { get; set; }
        
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }
        
    public PaymentStatus Status { get; set; }
        
    public DateTime PaymentDate { get; set; }

    public Reservation Reservation { get; set; }
}

public enum PaymentStatus
{
    Pending,
    Paid,
    Failed
}