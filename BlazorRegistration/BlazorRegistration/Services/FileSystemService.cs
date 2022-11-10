using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BlazorRegistration.Services;

public class FileSystemService
{
    public async Task UploadImageToDbAsync(Stream stream, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("BlazorImages");
        var gridFS = new GridFSBucket(database);
        
        await gridFS.UploadFromStreamAsync(fileName, stream);
    }

    public string DownloadToLocal(string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("BlazorImages");
        var gridFS = new GridFSBucket(database);
        
        using (FileStream fs =
               new FileStream(
                   $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/Images/")}{fileName}",
                   FileMode.OpenOrCreate))
        {
            gridFS.DownloadToStreamByName(fileName, fs);
        }

        return $"Images/{fileName}";
    }

    public List<string> UploadImages()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("BlazorImages");
        var collection = database.GetCollection<GridFSFileInfo>("fs.files");
        var images = collection.Find(x => true).ToList();
        var nameImages = new List<string>();

        foreach (var img in images)
        {
            nameImages.Add(img.Filename);
        }

        return nameImages;
    }
}