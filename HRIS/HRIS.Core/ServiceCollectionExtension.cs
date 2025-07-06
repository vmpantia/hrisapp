using System.Reflection;
using HRIS.Core.Pipelines;
using HRIS.Core.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Core;

public static class ServiceCollectionExtension
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddRequestSenderAndHandlers();
        services.AddPipelines();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    private static void AddRequestSenderAndHandlers(this IServiceCollection services)
    {
        // Register handlers
        var handlerTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

        foreach (var handler in handlerTypes)
        {
            var handlerInterface = handler.GetInterfaces().First(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

            services.AddScoped(handlerInterface, handler);
        }
        
        // Register sender
        services.AddScoped<IRequestSender, RequestSender>();
    }

    private static void AddPipelines(this IServiceCollection services) =>
        services.AddScoped(typeof(IPipeline<,>), typeof(DbTransactionPipeline<,>));
}