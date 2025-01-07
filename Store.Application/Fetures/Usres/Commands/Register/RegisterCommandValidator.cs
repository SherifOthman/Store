using FluentValidation;

namespace Store.Application.Fetures.Usres.Commands.Register;
public class RegisterCommandValidator :AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MinimumLength(6).WithMessage("{PropertyName} must not be less than 6 characters");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Length(11).WithMessage("{PropertyName} must be 11 characters");

    }
}
