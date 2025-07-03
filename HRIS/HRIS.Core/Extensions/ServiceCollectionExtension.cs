using HRIS.Core.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Core.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddCore(this IServiceCollection services) =>
        services.AddRequestHandlers();

    private static void AddRequestHandlers(this IServiceCollection services)
    {
        var handlerTypes = typeof(DipendencyInjectionAssembly).Assembly
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
    }
}