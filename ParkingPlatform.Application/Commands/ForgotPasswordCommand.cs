using MediatR;
using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Commands;

public record ForgotPasswordCommand(string Email) : IRequest<AuthResultDto>; 