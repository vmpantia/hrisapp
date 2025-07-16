using HRIS.Shared.Models.Users;

namespace HRIS.Web.Services.Contracts;

public interface IAuthenticationService
{
    Task LoginAsync(LoginUserDto login);
    Task LogoutAsync();
}