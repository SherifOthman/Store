
using FluentValidation;

namespace Store.Application.Fetures.Usres.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("Email must not exceed 50 characters.")
            .EmailAddress().WithMessage("Email is not a valid email");

        RuleFor(x => x.Password).
            NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("Email must not exceed 20 characters.");
    }
}
