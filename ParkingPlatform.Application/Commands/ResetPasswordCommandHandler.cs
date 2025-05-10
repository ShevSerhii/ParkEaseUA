using MediatR;
using Microsoft.AspNetCore.Identity;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Infrastructure.Models;

namespace ParkingPlatform.Application.Commands;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, AuthResultDto>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AuthResultDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken = default)
    {
        var model = request.Model;
        
        // Find user by email
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            // Don't reveal that the user doesn't exist
            return new AuthResultDto { Success = false, Message = "Password reset failed" };
        }

        try
        {
            // Reset password using the code
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.NewPassword);

            if (result.Succeeded)
            {
                return new AuthResultDto { Success = true, Message = "Password has been reset successfully" };
            }

            return new AuthResultDto
            {
                Success = false,
                Message = "Password reset failed",
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        catch (Exception ex)
        {
            return new AuthResultDto
            {
                Success = false,
                Message = "Password reset error",
                Errors = new[] { ex.Message }
            };
        }
    }
} 