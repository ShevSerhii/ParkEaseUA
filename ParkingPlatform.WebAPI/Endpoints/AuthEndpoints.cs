using MediatR;
using Microsoft.AspNetCore.Authorization;
using ParkingPlatform.Application.Comands;
using ParkingPlatform.Application.DTOs.Auth;
using ParkingPlatform.Application.Queries;
using ParkingPlatform.WebAPI.Routes;

namespace ParkingPlatform.WebAPI.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiRoutes.Base);

        group.MapPost(ApiRoutes.Register, async (
            ISender sender, 
            RegisterDto model, 
            CancellationToken cancellationToken = default) =>
        {
            var result = await sender.Send(new RegisterUserCommand(model), cancellationToken);

            return result.Success
                ? Results.Ok(new {massage = result.Message})
                : Results.BadRequest(new {message = result.Message, errors = result.Errors });
            
        });

        group.MapPost(ApiRoutes.Login, async (
            ISender sender, 
            LoginDto model, 
            CancellationToken cancellationToken = default) =>
        {
            var result = await sender.Send(new GetJwtTokenQuery(model), cancellationToken);

            return result.Success
                ? Results.Ok(new { massage = result.Message, token = result.Token })
                : Results.BadRequest(new {message = result.Message, errors = result.Errors });
        });

        group.MapGet(ApiRoutes.OnlyDriver, [Authorize(Roles = "Driver")] () => Results.Ok("Welcome, driver!"));
    }
}