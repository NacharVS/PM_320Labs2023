namespace AuthorizationApp.Services.Interfaces;

public interface IFileService
{
    public Task UploadFile(string path);
    public Task UploadFileAsync(string filename, string path);
    public Task UploadFileAsync(string filename, Stream file);
    public void UploadFile(string filename, string path);
    public Task<bool> FileExistsAsync(string filename);
    public bool FileExists(string filename);
    public Task DownloadFileFromStream(string filename, Stream stream);
    public Task DownloadFileToPath(string filename, string path);
    public Task<Stream> DownloadFileToStream(string filename);
}