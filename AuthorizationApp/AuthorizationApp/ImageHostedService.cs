using AuthorizationApp.Services.Interfaces;

namespace AuthorizationApp;

public class ImageHostedService : IHostedService
{
    private const string PathToSave = "wwwroot/images";

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ImageHostedService> _logger;

    public ImageHostedService(IServiceProvider serviceProvider,
        ILogger<ImageHostedService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var imageService = scope.ServiceProvider.GetService<IImageService>()!;

            await imageService.InitializeImages();

            _logger.Log(LogLevel.Information, "Картинки подгружены");
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Ошибка при подкачке картинок {e.Message}");
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}