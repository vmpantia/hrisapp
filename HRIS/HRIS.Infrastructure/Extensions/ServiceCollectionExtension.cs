using HRIS.Infrastructure.Databases.Contexts;
using HRIS.Infrastructure.Databases.Repositories;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration);
    }
    
    private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<HRISDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("HRIS")));

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}