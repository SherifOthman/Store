
using Microsoft.OpenApi.Writers;
using Store.Application.Contracts.Persistence;

namespace Store.Api.BackgroundTasks;

public class RefreshTokensCleanerTask : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RefreshTokensCleanerTask> _logger;

    public RefreshTokensCleanerTask(IServiceProvider serviceProvider,
        ILogger<RefreshTokensCleanerTask> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromHours(1),stoppingToken);

            using (var scope = _serviceProvider.CreateScope())
            {
                var refreshTokenRepository = scope.ServiceProvider.GetRequiredService<IRefreshTokenRpository>();

                _logger.LogInformation("Cleaning Refresh Table started");
                int totalTokensRemoved = await refreshTokenRepository.RemoveInvalidTokens();
                _logger.LogInformation("Cleaning Refresh Table finished with {@totalTokens} removed", totalTokensRemoved);
            }

        }
    }
}
