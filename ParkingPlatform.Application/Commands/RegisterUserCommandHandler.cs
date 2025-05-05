using MediatR;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.Application.Comands;

public class RegisterUserCommandHandler(IAuthService authService) : IRequestHandler<RegisterUserCommand, AuthResultDto>
{
    private readonly IAuthService _authService = authService;

    public Task<AuthResultDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return _authService.RegisterAsync(request.Model, cancellationToken);
    }
}
