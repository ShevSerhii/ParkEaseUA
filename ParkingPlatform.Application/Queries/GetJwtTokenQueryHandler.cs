using MediatR;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.Application.Queries;

public class GetJwtTokenQueryHandler : IRequestHandler<GetJwtTokenQuery, AuthResultDto>
{
    private readonly IAuthService _authService;

    public GetJwtTokenQueryHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<AuthResultDto> Handle(GetJwtTokenQuery request, CancellationToken cancellationToken)
    {
        return _authService.LoginAsync(request.Model, cancellationToken);
    }
}