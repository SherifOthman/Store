
using FluentValidation;

namespace Store.Application.Fetures.Usres.Commands.RefreshTokens;
public class RefreshTokenCommandValidation : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidation()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("{PropertyName} Is required");
    }
}
