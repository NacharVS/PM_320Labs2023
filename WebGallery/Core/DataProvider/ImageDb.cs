using Microsoft.Win32;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Core.DataProvider;

public static class ImageDb
{
    private static readonly MongoClient Client = new("mongodb://localhost");
    private static readonly IMongoDatabase Database = Client.GetDatabase("Image");
    private static readonly GridFSBucket FileWorker = new(Database);
    private static readonly string DownloadsFolder = "downloads";//GetDownloadFolderPath();

    public static async Task UploadImageToDb(string fileName)
    {
        var fileInfo =
            await FileWorker.FindAsync(Builders<GridFSFileInfo>.Filter.Eq(info => info.Filename, fileName));

        if (fileInfo.FirstOrDefault() is null)
        {
            await using FileStream fs = new FileStream($"{Directory.GetCurrentDirectory()}/wwwroot/upload/{fileName}", FileMode.Open);
            await FileWorker.UploadFromStreamAsync(fileName, fs);
        }
    }

    public static async Task DownloadToLocal(string fileName)
    {
        try
        {
            await using FileStream fs = new FileStream(
                $"{DownloadsFolder}/{fileName}",
                FileMode.Create);
            await FileWorker.DownloadToStreamByNameAsync(fileName, fs);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static string[] GetAllImages()
    {
        var fileInfo =
             FileWorker.Find(Builders<GridFSFileInfo>.Filter.Empty);


        
        return fileInfo.ToList().Select(x => x.Filename).ToArray();
    }
    
    private static string GetDownloadFolderPath() 
    {
        return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", 
            "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty)?.ToString() ?? "downloads";
    }
}