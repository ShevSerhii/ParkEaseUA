using MediatR;
using Microsoft.AspNetCore.Identity;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;
using ParkingPlatform.Infrastructure.Models;

namespace ParkingPlatform.Application.Commands;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, AuthResultDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _emailSender;

    public ForgotPasswordCommandHandler(
        UserManager<ApplicationUser> userManager,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
    }

    public async Task<AuthResultDto> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken = default)
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
        
        // Send email with reset code
        string subject = "Password Reset";
        string message = $"Your password reset code is: {code}";
        
        await _emailSender.SendEmailAsync(request.Email, subject, message);

        return new AuthResultDto { Success = true, Message = "If your email is registered, you will receive a password reset code." };
    }
} 