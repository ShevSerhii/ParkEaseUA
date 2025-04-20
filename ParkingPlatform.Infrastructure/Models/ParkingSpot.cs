using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingPlatform.Infrastructure.Models;

public class ParkingSpot
{
    public int Id { get; set; }

    [Required]
    public int ParkingLotId { get; set; }

    [ForeignKey(nameof(ParkingLotId))]
    public ParkingLot ParkingLot { get; set; }

    public bool IsAvailable { get; set; } = true;

    public string SpotNumber { get; set; }
}