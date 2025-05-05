using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Helpers;
using ParkingPlatform.Infrastructure.Models;

namespace ParkingPlatform.Application.Queries;

public class GetJwtTokenQueryHandler : IRequestHandler<GetJwtTokenQuery, AuthResultDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public GetJwtTokenQueryHandler(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<AuthResultDto> Handle(GetJwtTokenQuery request, CancellationToken cancellationToken = default)
    {
        var model = request.Model;

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return new AuthResultDto
            {
                Success = false,
                Message = "Invalid email or password"
            };
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!isPasswordValid)
        {
            return new AuthResultDto
            {
                Success = false,
                Message = "Invalid email or password"
            };
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = JwtTokenHelper.GenerateToken(_configuration, user.Id, user.Email, roles);

        return new AuthResultDto
        {
            Success = true,
            Message = "Login successful",
            Token = token
        };
    }
}