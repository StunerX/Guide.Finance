using Guide.Finance.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Guide.Finance.Configurations;

public static class ConnectionsConfiguration
{
    public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbConnection(configuration);
        return services;
    }

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("GuideFinanceDb");
        services.AddDbContext<GuideFinanceDbContext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        return services;
    }
}