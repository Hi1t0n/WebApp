using AuthService.Domain;
using AuthService.Infrastructure.Contexts;
using AuthService.Infrastructure.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    // Добавляем бизнес-логику
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration,
        string connectionString)
    {
        services.AddManagers();
        services.AddDatabase(connectionString);
        return services;
    }

    //Добавление менеджеров
    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IAuthManager, AuthManager>();
        return services;
    }

    //Добавление Базы Данных
    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UserContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }
}