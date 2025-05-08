using MediatR;
using Microsoft.AspNetCore.Identity;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Infrastructure.Models;

namespace ParkingPlatform.Application.Commands;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, AuthResultDto>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ForgotPasswordCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AuthResultDto> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        // Find user by email
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            //for security
            return new AuthResultDto { Success = true, Message = "If your email is registered, you will receive a password reset code." };
        }

        // Generate password reset code
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        
        // Output code to console (in a real app, send via email)
        Console.WriteLine($"[PASSWORD RESET CODE] Email: {request.Email}, Code: {code}");

        return new AuthResultDto { Success = true, Message = "If your email is registered, you will receive a password reset code." };
    }
} 