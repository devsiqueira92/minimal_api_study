using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Application.UseCases.User.GetAllUsersUseCase;
using MinimalAPI.Application.UseCases.User.GetMyUserUseCase;
using MinimalAPI.Application.UseCases.User.RegisterUserUseCase;
using MinimalAPI.Application.Utils.LoggedUser;
using MinimalAPI.Application.Utils.Token;

namespace MinimalAPI.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddTokenConfiguration(services, configuration);
        AddTokenJWT(services, configuration);
        AddUseCases(services);
        AddServices(services);
    }


    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>()
            .AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>()
            .AddScoped<IGetMyUserUseCase, GetMyUserUseCase>();
    }

    private static void AddTokenConfiguration(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "localhost",
                ValidAudience = "localhost",
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration.GetSection("Configurations:Jwt:TokenKey").Value))
            };

        });
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ILoggedUser, LoggedUser>();
    }
    private static void AddTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTempoDeVida = configuration.GetRequiredSection("Configurations:Jwt:LifeTimeTokenMinutes");
        var sectionKey = configuration.GetRequiredSection("Configurations:Jwt:TokenKey");

        services.AddScoped<ITokenController>(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }
}
