using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterDto model, CancellationToken cancellationToken);
        Task<AuthResult> LoginAsync(LoginDto model, CancellationToken cancellationToken);
    }
}