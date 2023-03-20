using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPI.Domain.RepositoryInterface;
using MinimalAPI.Infrastructure.Context;
using MinimalAPI.Infrastructure.Repository;

namespace MinimalAPI.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddContext(services, configurationManager);
        AddRepositories(services);
    }

    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddDbContext<UserContext>(dbContext =>
        {
            dbContext.UseSqlServer(configurationManager.GetConnectionString("Connection"));
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserInfoRepository, UserInfoRepository>();
    }
}
