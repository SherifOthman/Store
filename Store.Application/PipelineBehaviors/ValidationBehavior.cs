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

            var MappedInvalidValidationResults = validationResults.Where(v => !v.IsValid).ToValidationErrorMap();

            if (MappedInvalidValidationResults.Any())
                return CreateFailureResponse(MappedInvalidValidationResults);
        }

        return await next();
    }

    private static TResponse CreateFailureResponse(IDictionary<string, string[]> validationErrors)
    {
        // Handle `Result<T>` responses
        if (typeof(TResponse).IsGenericType &&
            typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
        {

            // Use reflection to create an instance of `Result<T>`
            var resultType = typeof(TResponse).GetGenericArguments()[0];
            var genericResultType = typeof(Result<>).MakeGenericType(resultType);

            // Handling by creaeting instance

            var result = Activator.CreateInstance(genericResultType) as BaseResult;

            if (result != null)
            {
                result.IsSuccess = false;
                result.Message = "Validation Error";
                result.Errors = validationErrors;
            }

            return (TResponse)(object)result!;

            // Handling by method

            //var failureConstructor = genericResultType.GetMethod(nameof(BaseResult.FailureWithErrors));
            //if (failureConstructor != null)
            //{
            //    return (TResponse)failureConstructor.Invoke(null, new object[] { validationErrors });
            //}
        }


        // Handle `Result` (non-generic) responses
        if (typeof(TResponse) == typeof(BaseResult))
        {
            return (TResponse)(object)BaseResult.FailureWithErrors(validationErrors);
        }

        throw new Exceptions.ValidationException(validationErrors);
    }

}
