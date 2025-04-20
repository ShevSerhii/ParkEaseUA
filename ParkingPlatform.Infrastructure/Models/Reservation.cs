using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingPlatform.Infrastructure.Models;

public class Reservation
{

    public int Id { get; set; }

    [ForeignKey("Driver")]
    public int DriverId { get; set; }
        
    [ForeignKey("ParkingLot")]
    public int ParkingLotId { get; set; }
        
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    [Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; }
        
    public ReservationStatus Status { get; set; }

    
    public Driver Driver { get; set; }
    public ParkingLot ParkingLot { get; set; }
    public Payment Payment { get; set; }
}

public enum ReservationStatus
{
    Pending,
    Confirmed,
    Completed,
    Canceled
}