using AuthorizationApp.Database;
using AuthorizationApp.Services.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace AuthorizationApp.Services;

public class ImageService : IImageService
{
    private const string PathToSave = "wwwroot/images";

    private readonly GridFSBucket _fileSystem;
    private readonly IFileService _fileService;

    public ImageService(MongoConnection connection, IFileService fileService)
    {
        _fileService = fileService;
        _fileSystem = new GridFSBucket(connection.Database);
    }

    public async Task<IEnumerable<string>> GetAllImages()
    {
        return (await _fileSystem.FindAsync(FilterDefinition<GridFSFileInfo>.Empty))
            .ToEnumerable()
            .Select(x => x.Filename);
    }

    public async Task InitializeImages()
    {
        Directory.CreateDirectory(PathToSave);
        var images = (await GetAllImages()).ToList();
        foreach (var image in images)
        {
            var file = PathToSave + $"/{image}";
            if (!File.Exists(file))
                await _fileService.DownloadFileToPath(image, file);
        }
    }

    private void AddImagesToDb()
    {
        foreach (var file in Directory.GetFiles("wwwroot/images"))
        {
            if (!_fileService.FileExists(Path.GetFileName(file)))
                _fileService.UploadFile(Path.GetFileName(file), file);
        }
    }
}