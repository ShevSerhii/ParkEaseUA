using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingPlatform.Infrastructure.Models;

public class Notification
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public int DriverId { get; set; }
    public NotificationStatus status { get; set; } = NotificationStatus.Unread;

    public Driver Driver { get; set; }
}

public enum NotificationStatus
{
    Unread,
    Read,
}