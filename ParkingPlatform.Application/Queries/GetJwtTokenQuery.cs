using MediatR;
using ParkingPlatform.Application.DTOs.Auth;

namespace ParkingPlatform.Application.Queries;

public record GetJwtTokenQuery(LoginDto Model) : IRequest<AuthResultDto>;