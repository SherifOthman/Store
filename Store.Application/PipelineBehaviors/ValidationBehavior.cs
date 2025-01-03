using FluentValidation;
using MediatR;
using Store.Application.Extentions;
using Store.Application.Responses;


namespace Store.Application.Behaviors;
public class ValidationBehavior<TRequset, TResponse> : IPipelineBehavior<TRequset, TResponse>
    where TRequset : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequset>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequset>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequset request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var validationContext = new ValidationContext<TRequset>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(request)));

            var InvalidValidationResults = validationResults.Where(v => !v.IsValid);

            if (InvalidValidationResults.Any())
                throw new Exceptions.ValidationException(InvalidValidationResults.ToValidationErrorMap());

        }

        return await next();
    }
}
