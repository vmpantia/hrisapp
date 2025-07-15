using FluentValidation;
using HRIS.Core.Employees.Commands;
using HRIS.Core.Users.Contracts;
using HRIS.Infrastructure.Databases.Repositories.Contracts;
using HRIS.Shared.Models.Users;
using HRIS.Shared.Results;
using HRIS.Shared.Results.Errors;
using HRIS.Shared.Validators;
using MediatR;

namespace HRIS.Core.Users.Commands;

public sealed record LoginUserCommand(LoginUserDto Login) : IRequest<Result<UserTokenDto>>;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(luc => luc.Login)
            .SetValidator(new LoginUserValidator());
    }
}

public sealed class LoginUserCommandHandler(IUserRepository userRepository, 
    IPasswordHasher passwordHasher,
    ITokenProvider tokenProvider) : IRequestHandler<LoginUserCommand, Result<UserTokenDto>>
{
    public async Task<Result<UserTokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Get user using username or email in the database
        var user = await userRepository.GetUserAsync(request.Login.UsernameOrEmailAddress, cancellationToken);

        // Check if user found in the database
        if (user == null) return UserError.UsernameOrEmailAddressNotFound();
        
        // Check if user password matches on the given password using password hasher
        if (!passwordHasher.Verify(request.Login.Password, user.Password)) return UserError.PasswordIncorrect();

        // Generate authentication token for user
        return tokenProvider.Create(user);
    }
}