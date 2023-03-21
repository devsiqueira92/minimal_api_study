using Microsoft.AspNetCore.Mvc;
using MinimalAPI.API.Filters;
using MinimalAPI.API.Validators.User;
using MinimalAPI.Application.UseCases.User.GetAllUsersUseCase;
using MinimalAPI.Application.UseCases.User.GetMyUserUseCase;
using MinimalAPI.Application.UseCases.User.RegisterUserUseCase;
using MinimalAPI.Shared.Communication.Request;
using MinimalAPI.Shared.Communication.Response;
using MinimalAPI.Shared.Exceptions;

namespace MinimalAPI.API.Endpoints;

public static class UserEndpoint
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        app.MapGet("get-my-user", GetMyUser)
            .Produces<List<UserInfoResponse>>();

        app.MapGet("user/{id:guid}", GetUserById);
        app.MapGet("users", GetAll);
        app.MapPost("user", CreateUser)
            .AddEndpointFilter<ValidationFilter<UserRegisterRequest>>()
            .AllowAnonymous();

        app.MapPut("user", UpdateUser);
        app.MapDelete("user", CreateUser);
    }

    public static async Task<IResult> GetMyUser([FromServices] IGetMyUserUseCase service)
    {
        var user = await service.GetMyUser();
        return Results.Ok(user);
    }
    public static async Task<IResult> GetUserById([FromServices] IGetMyUserUseCase service)
    {
        var user = await service.GetMyUser();
        return Results.Ok(user);
    }
    public static async Task<IResult> GetAll([FromServices] IGetAllUsersUseCase service)
    {
        var user = await service.Execute();
        return Results.Ok(user);
    }
    public static async Task<IResult> CreateUser([FromServices] IRegisterUserUseCase service, [FromBody] UserRegisterRequest request)
    {
        var loggedUser = await service.Execute(request);
        return Results.Ok(loggedUser);
    }

    public static async Task<IResult> UpdateUser([FromServices] IGetMyUserUseCase service)
    {
        var user = await service.GetMyUser();
        return Results.Ok(user);
    }

    public static async Task<IResult> DeleteUser([FromServices] IGetMyUserUseCase service)
    {
        var user = await service.GetMyUser();
        return Results.Ok(user);
    }
}
