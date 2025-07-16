using HRIS.Shared.Models.Users;
using HRIS.Web.Providers;
using HRIS.Web.Providers.Contracts;
using HRIS.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HRIS.Web.Services;

public class AuthenticationService(IHttpClientProvider httpClientProvider, 
    AuthenticationStateProvider authenticationStateProvider, 
    NavigationManager navigationManager,
    ILogger<AuthenticationService> logger) : IAuthenticationService
{
    
    public async Task LoginAsync(LoginUserDto login)
    {
        try
        {
            // Send login request to API
            var token = await httpClientProvider.PostAsync<UserTokenDto>("https://localhost:7104/api/Auth/Login", login);

            // Check if the token is NOT NULL or Empty
            if (!string.IsNullOrEmpty(token.Token))
            {
                // Mark user as authenticate using the custom authentication state provider
                await ((CustomAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(token.Token);

                // Redirect user to the main page
                navigationManager.NavigateTo("/");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error in processing login request | Message: {ex.Message}");
        }
    }

    public async Task LogoutAsync()
    {
        // Mark user as logged out using the custom authentication state provider
        await ((CustomAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();

        // Redirect user to the login page
        navigationManager.NavigateTo("/login");
    }
}