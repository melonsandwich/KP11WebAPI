using KP11.Integration.Models;
using KP11WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;

namespace KP11WebAPI.APIs;

public class AuthAPI : IAPI
{
    private WebApplication _app;
    public void Register(WebApplication app)
    {
        //app.MapGet("/auth", Authorize);
        app.MapGet("/auth", [AllowAnonymous] async (HttpContext context, ITokenService tokenService, IUserRepository userRepository) =>
            {
                UserModel model = new()
                {
                    Login = context.Request.Query["login"]!,
                    Password = context.Request.Query["password"]!
                };
                UserDto dto = userRepository.GetUser(model);
                if (dto == null!)
                    return Results.Unauthorized();

                string token =
                    tokenService.BuildToken(app.Configuration["Jwt:Key"]!, app.Configuration["Jwt:Issuer"]!, dto);
                return Results.Ok(token);
            });
    }

    [AllowAnonymous]
    private async Task<IResult> Authorize(HttpContext context, ITokenService tokenService, IUserRepository userRepository)
    {
        UserModel model = new()
        {
            Login = context.Request.Query["login"]!,
            Password = context.Request.Query["password"]!
        };
        UserDto dto = userRepository.GetUser(model);
        if (dto == null!)
            return Results.Unauthorized();

        string token =
            tokenService.BuildToken(_app.Configuration["Jwt:Key"]!, _app.Configuration["Jwt:Issuer"]!, dto);
        return Results.Ok(token);
    }
}