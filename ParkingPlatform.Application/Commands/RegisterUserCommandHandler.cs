using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ParkingPlatform.Application.Comands;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Infrastructure.Models;


namespace ParkingPlatform.Application.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResultDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RegisterUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AuthResultDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken = default)
    {
        var model = request.Model;

        // Check if user already exists
        var existingUser = await _userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
        {
            return new AuthResultDto
            {
                Success = false,
                Message = "User already exists"
            };
        }

        // Create new user
        var user = new ApplicationUser
        {
            Email = model.Email,
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            EmailConfirmed = true  // Auto-confirm email
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return new AuthResultDto
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description),
                Message = "User creation failed"
            };
        }

        // Assign role
        if (!await _roleManager.RoleExistsAsync(model.Role))
        {
            await _roleManager.CreateAsync(new IdentityRole(model.Role));
        }

        await _userManager.AddToRoleAsync(user, model.Role);

        return new AuthResultDto
        {
            Success = true,
            Message = "User registered successfully"
        };
    }
}