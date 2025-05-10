using MediatR;
using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Commands;

public record ResetPasswordCommand(ResetPasswordDto Model) : IRequest<AuthResultDto>; 