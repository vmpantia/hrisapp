using HRIS.Infrastructure.Databases.Contexts;
using HRIS.Infrastructure.Databases.Interceptors;
using HRIS.Infrastructure.Databases.Repositories;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration);
        services.AddRepositories();
        services.AddInterceptors();
    }

    private static void AddInterceptors(this IServiceCollection services)
    {
        services.AddSingleton<AuditEntitiesInterceptor>();
    }

    private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HRISDbContext>((sp, opt) =>
        {
            var interceptor = sp.GetRequiredService<AuditEntitiesInterceptor>();

            opt.UseSqlServer(configuration.GetConnectionString("MigrationDb"))
                .AddInterceptors(interceptor);
        });
    }

    private static void AddRepositories(this IServiceCollection services) =>
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
}