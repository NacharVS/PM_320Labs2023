using Core.DataProvider;

namespace Web.Services;

public class FileService
{


    public async Task DownloadImage(string fileName)
    {
        await ImageDb.DownloadToLocal(fileName);
    }

    public List<string> LoadAllImages()
    {
        return Directory.EnumerateFiles("wwwroot/upload")
            .Where(x => x.Contains(".jpg")).Select(x => x.Split("/")[^1])
            .ToList();
    }

    public string[] GetAllImages()
    {
        return ImageDb.GetAllImages();
    }
    public async Task UploadAllImages()
    {
        foreach (var filePath in LoadAllImages())
        {
            await ImageDb.UploadImageToDb(filePath);
        }
    }
}