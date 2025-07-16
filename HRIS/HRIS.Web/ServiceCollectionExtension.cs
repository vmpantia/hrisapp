using HRIS.Web.Providers;
using HRIS.Web.Providers.Contracts;
using HRIS.Web.Services;
using HRIS.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;

namespace HRIS.Web;

public static class ServiceCollectionExtension
{
    public static void AddProviders(this IServiceCollection services)
    {
        services.AddScoped<IHttpClientProvider, HttpClientProvider>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}