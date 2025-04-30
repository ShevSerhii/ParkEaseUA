using Microsoft.AspNetCore.Authorization;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.WebAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth");

        group.MapPost("/register", async (IAuthService authService, RegisterDto model, CancellationToken cancellationToken = default) =>
        {
            var result = await authService.RegisterAsync(model, cancellationToken);

            return result.Success
                ? Results.Ok(new {massage = result.Message})
                : Results.BadRequest(new {message = result.Message, errors = result.Errors });
            
        });

        group.MapPost("/login", async (IAuthService authService, LoginDto model, CancellationToken cancellationToken = default) =>
        {
            var result = await authService.LoginAsync(model, cancellationToken);

            return result.Success
                ? Results.Ok(new { massage = result.Message, token = result.Token })
                : Results.BadRequest(new {message = result.Message, errors = result.Errors });
        });

        group.MapGet("/only-driver", [Authorize(Roles = "Driver")] () => Results.Ok("Welcome, driver!"));
    }
}