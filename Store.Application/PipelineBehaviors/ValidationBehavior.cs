using FluentValidation;
using MediatR;
using Store.Application.Extentions;
using Store.Application.Responses;
using System;
using System.Reflection;

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

            var MappedInvalidValidationResults = validationResults.Where(v => !v.IsValid).ToValidationErrorMap();

            if (MappedInvalidValidationResults.Any())
            {
                if (typeof(TResponse).IsGenericType
                    && typeof(TResponse).GetGenericTypeDefinition() == typeof(Response<>))

                    return CreateFailureResponse(MappedInvalidValidationResults);

            }
        }

        return await next();
    }

    private static TResponse CreateFailureResponse(IDictionary<string, string[]> validationErrors)
    {
        var genricArg = typeof(TResponse).GetGenericArguments()[0];
        var failMethod = typeof(Response).GetMethod("Fail");
        var faliMethodWithGenricArg = failMethod!.MakeGenericMethod (genricArg);

        return (TResponse)faliMethodWithGenricArg.Invoke(
            null, new object[] { "Validation failed", validationErrors })!;

    }


}
