using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Managers;
using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Context;

namespace ProductService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services,IConfiguration configuration,
        string connectionString)
    {
        services.AddManagers();
        services.AddDatabase(connectionString);
        return services;
    }

    private static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IProductManager, ProductManager>();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ProductContext>(builder => builder.UseNpgsql(connectionString));
        return services;
    }



}