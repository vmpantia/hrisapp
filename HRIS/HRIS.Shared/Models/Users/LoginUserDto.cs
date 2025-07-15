namespace HRIS.Shared.Models.Users;

public sealed class LoginUserDto
{
    public string UsernameOrEmailAddress { get; set; }
    public string Password { get; set; }
}