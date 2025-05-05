using MediatR;
using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Comands;

public record RegisterUserCommand(RegisterDto Model) : IRequest<AuthResultDto>;