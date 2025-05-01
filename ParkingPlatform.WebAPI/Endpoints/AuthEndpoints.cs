using Microsoft.AspNetCore.Authorization;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.WebAPI.Endpoints;

public static class AuthEndpoints
{
    public static class Routes
    {
        public const string Base = "/api/auth";
        public const string Register = "/register";
        public const string Login = "/login";
        public const string OnlyDriver = "/only-driver";
    }
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(Routes.Base);

        group.MapPost( Routes.Register, async (IAuthService authService, RegisterDto model, CancellationToken cancellationToken = default) =>
        {
            var result = await authService.RegisterAsync(model, cancellationToken);

            return result.Success
                ? Results.Ok(new {massage = result.Message})
                : Results.BadRequest(new {message = result.Message, errors = result.Errors });
            
        });

        group.MapPost(Routes.Login, async (IAuthService authService, LoginDto model, CancellationToken cancellationToken = default) =>
        {
            var result = await authService.LoginAsync(model, cancellationToken);

            return result.Success
                ? Results.Ok(new { massage = result.Message, token = result.Token })
                : Results.BadRequest(new {message = result.Message, errors = result.Errors });
        });

        group.MapGet(Routes.OnlyDriver, [Authorize(Roles = "Driver")] () => Results.Ok("Welcome, driver!"));
    }
}