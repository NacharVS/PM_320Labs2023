using AuthorizationApp.Database;
using AuthorizationApp.Services.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace AuthorizationApp.Services;

public class ImageService : IImageService
{
    private readonly GridFSBucket _fileSystem;
    private readonly IFileService _fileService;

    public ImageService(MongoConnection connection, IFileService fileService)
    {
        _fileService = fileService;
        _fileSystem = new GridFSBucket(connection.Database);
        AddImagesToDb();
    }

    public async Task<IEnumerable<string>> GetAllImages()
    {
        return (await _fileSystem.FindAsync(FilterDefinition<GridFSFileInfo>.Empty))
            .ToEnumerable()
            .Select(x => x.Filename);
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