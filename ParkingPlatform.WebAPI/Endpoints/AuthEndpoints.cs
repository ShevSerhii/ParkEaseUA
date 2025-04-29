using Microsoft.AspNetCore.Authorization;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.WebAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth");

        group.MapPost("/register", async (IAuthService authService, RegisterDto model, CancellationToken cancellationToken) =>
        {
            var result = await authService.RegisterAsync(model, cancellationToken);

            if (!result.Success)
            {
                return Results.BadRequest(new
                {
                    message = result.Message,
                    errors = result.Errors
                });
            }

            return Results.Ok(new
            {
                message = result.Message
            });
        });

        group.MapPost("/login", async (IAuthService authService, LoginDto model, CancellationToken cancellationToken) =>
        {
            var result = await authService.LoginAsync(model, cancellationToken);

            if (!result.Success)
            {
                return Results.BadRequest(new
                {
                    message = result.Message,
                    errors = result.Errors
                });
            }

            return Results.Ok(new
            {
                message = result.Message,
                token = result.Token
            });
        });

        group.MapGet("/only-driver", [Authorize(Roles = "Driver")] () =>
        {
            return Results.Ok("Welcome, driver!");
        });
    }
}