using MediatR;
using Microsoft.AspNetCore.Authorization;
using ParkingPlatform.Application.Comands;
using ParkingPlatform.Application.Commands;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Queries;
using ParkingPlatform.WebAPI.Routes;

namespace ParkingPlatform.WebAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiRoutes.Base);

        // Register endpoint
        group.MapPost(ApiRoutes.Register, async (
            ISender sender, 
            RegisterDto model, 
            CancellationToken cancellationToken = default) =>
        {
            var result = await sender.Send(new RegisterUserCommand(model), cancellationToken);

            return result.Success
                ? Results.Ok(new { message = result.Message })
                : Results.BadRequest(new { message = result.Message, errors = result.Errors });
        });

        // Login endpoint
        group.MapPost(ApiRoutes.Login, async (
            ISender sender, 
            LoginDto model, 
            CancellationToken cancellationToken = default) =>
        {
            var result = await sender.Send(new GetJwtTokenQuery(model), cancellationToken);
            return result.Success
                ? Results.Ok(new { message = result.Message, token = result.Token })
                : Results.BadRequest(new { message = result.Message, errors = result.Errors });
        });

        // Protected endpoint example
        group.MapGet(ApiRoutes.OnlyDriver, [Authorize(Roles = "Driver")] () => 
            Results.Ok("Welcome, driver!"));
        
        // Forgot password endpoint
        group.MapPost(ApiRoutes.ForgotPassword, async (
            ISender sender,
            ForgotPasswordDto model,
            CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new ForgotPasswordCommand(model.Email), cancellationToken);
            return Results.Ok(new { message = result.Message });
        })
        .WithName("ForgotPassword")
        .WithOpenApi();
        
        // Reset password endpoint
        group.MapPost(ApiRoutes.ResetPassword, async (
            ISender sender,
            ResetPasswordDto model,
            CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new ResetPasswordCommand(model), cancellationToken);
            return result.Success
                ? Results.Ok(new { message = result.Message })
                : Results.BadRequest(new { message = result.Message, errors = result.Errors });
        })
        .WithName("ResetPassword")
        .WithOpenApi();
    }
}