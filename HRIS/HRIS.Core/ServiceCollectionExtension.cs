using System.Reflection;
using HRIS.Core.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using HRIS.Core.Users;
using HRIS.Core.Users.Contracts;

namespace HRIS.Core;

public static class ServiceCollectionExtension
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddMediatR();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<ITokenProvider, TokenProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
    }

    private static void AddMediatR(this IServiceCollection services) =>
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationPipeline<,>));
            config.AddOpenBehavior(typeof(DbTransactionPipeline<,>));
        });
}