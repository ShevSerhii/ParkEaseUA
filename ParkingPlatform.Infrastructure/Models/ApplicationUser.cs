using Microsoft.AspNetCore.Identity;

namespace ParkingPlatform.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Address { get; set; }
        public bool IsVerified { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
