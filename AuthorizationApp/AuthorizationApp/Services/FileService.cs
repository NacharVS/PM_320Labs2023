using AuthorizationApp.Database;
using AuthorizationApp.Services.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace AuthorizationApp.Services;

public class FileService : IFileService
{
    private readonly GridFSBucket _fileSystem;

    public FileService(MongoConnection connection)
    {
        _fileSystem = new GridFSBucket(connection.Database);
    }

    public async Task UploadFile(string path)
    {
        var filename = Path.GetFileName(path);
        await UploadFileAsync(filename, path);
    }

    public void UploadFile(string filename, string path)
    {
        using var stream = new FileStream(path, FileMode.Open);
        _fileSystem.UploadFromStream(filename, stream);
    }

    public async Task<bool> FileExistsAsync(string filename)
    {
        return (await _fileSystem.FindAsync(FilterDefinition<GridFSFileInfo>.Empty)).ToEnumerable()
            .Any(x => x.Filename == filename);
    }

    public bool FileExists(string filename)
    {
        return _fileSystem.Find(FilterDefinition<GridFSFileInfo>.Empty).ToEnumerable().Any(x => x.Filename == filename);
    }

    public async Task UploadFileAsync(string filename, string path)
    {
        await using var stream = new FileStream(path, FileMode.Open);
        await _fileSystem.UploadFromStreamAsync(filename, stream);
    }

    public async Task DownloadFileToPath(string filename, string path)
    {
        await using var stream = File.Create(path);
        await _fileSystem.DownloadToStreamByNameAsync(filename, stream);
    }

    public async Task<Stream> DownloadFileToStream(string filename)
    {
        await using var stream = new MemoryStream();
        await _fileSystem.DownloadToStreamByNameAsync(filename, stream);

        return stream;
    }
}