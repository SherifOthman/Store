using MediatR;
using Microsoft.Extensions.Logging;
using Store.Application.Responses;

namespace Store.Application.PipelineBehaviors;
internal class LoggingPipeLineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipeLineBehavior(ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Processing Request {@RequestName}, {@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        var result = await next();

        if (result is Response<object> response)
        {
            if (response.Error) 
            {
                _logger.LogError(
                    "Request {@RequestName} failed with error: {@Error}, at {@DateTimeUtc}",
                    typeof(TRequest).Name,
                    response.Message,
                    DateTime.UtcNow);
            }
            else
            {
                _logger.LogInformation(
                    "Completed Request {@RequestName}, {@DateTimeUtc}",
                    typeof(TRequest).Name,
                    DateTime.UtcNow);
            }
        }
        else
        {
            // Log for non-Response results
            _logger.LogInformation(
                "Completed Request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);
        }

        return result;
    }
}
