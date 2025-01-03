using FluentValidation;
using MediatR;
using Store.Application.Extentions;
using Store.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.PipelineBehaviors;
public class ValidationBehaviorForResult<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result<object>

{
    private readonly IEnumerable<IValidator> _validators;

    public ValidationBehaviorForResult(IEnumerable<IValidator> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        if (_validators.Any())
        {
            var validationContext = new ValidationContext<TRequest>(request);

            var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

            var InValidValidationResut = validationResult.Where(r => !r.IsValid);

            var validationErrors = InValidValidationResut.ToValidationErrorMap();


            return (TResponse)Result<object>.Failure("Validation Error", validationErrors);

        }

        return await next();
    }
}
