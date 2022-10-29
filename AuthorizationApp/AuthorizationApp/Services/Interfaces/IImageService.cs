namespace AuthorizationApp.Services.Interfaces;

public interface IImageService
{
    public Task<IEnumerable<string>> GetAllImages();
    public Task InitializeImages();
}