using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParkingPlatform.Infrastructure.Enums;

namespace ParkingPlatform.Infrastructure.Models;

public class Reservation
{

    public int Id { get; set; }
    public int DriverId { get; set; }
    public int ParkingLotId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal TotalPrice { get; set; }
    public ReservationStatus Status { get; set; }
    
    public Driver Driver { get; set; }
    public ParkingLot ParkingLot { get; set; }
    public Payment Payment { get; set; }
}