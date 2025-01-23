using FluentValidation;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Application.Contracts.Persistence;
using Store.Application.Features.Users.Commands.Login;
using Store.Application.Validations;

namespace Store.Application.Features.Usres.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{

    public LoginCommandValidator(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(c => c.Email)
            .EmailAddress();

        RuleFor(c => c.Password)
            .NotEmpty();
    }

}
