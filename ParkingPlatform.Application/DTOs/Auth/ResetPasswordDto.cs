namespace ParkingPlatform.Application.DTOs.Auth;

public record ResetPasswordDto
{
    public string Email { get; set; }
    public string Code { get; set; }
    public string NewPassword { get; set; }
} 