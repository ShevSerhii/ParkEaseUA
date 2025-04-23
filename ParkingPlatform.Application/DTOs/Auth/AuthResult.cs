namespace ParkingPlatform.Application.DTOs.Auth
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        
        public string? Token { get; set; }
    }
}