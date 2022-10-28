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
            var fileService = scope.ServiceProvider.GetService<IFileService>()!;
            var imageService = scope.ServiceProvider.GetService<IImageService>()!;

            Directory.CreateDirectory(PathToSave);
            var images = (await imageService.GetAllImages()).ToList();
            foreach (var image in images)
            {
                var file = PathToSave + $"/{image}";
                if (!File.Exists(file))
                    await fileService.DownloadFileToPath(image, file);
            }

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