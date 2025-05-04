using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDto> RegisterAsync(RegisterDto model, CancellationToken cancellationToken = default);
        Task<AuthResultDto> LoginAsync(LoginDto model, CancellationToken cancellationToken = default);
    }
}