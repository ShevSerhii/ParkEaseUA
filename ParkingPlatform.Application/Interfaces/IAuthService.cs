using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterDto model);
    }
}