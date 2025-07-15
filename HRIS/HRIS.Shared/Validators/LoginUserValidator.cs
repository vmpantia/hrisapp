using FluentValidation;
using HRIS.Shared.Models.Users;

namespace HRIS.Shared.Validators;

public sealed class LoginUserValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserValidator()
    {
        RuleFor(e => e.UsernameOrEmailAddress).NotEmpty();
        RuleFor(e => e.Password).NotEmpty();
    }
}