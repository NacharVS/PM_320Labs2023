using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BlazorRegistration.Services;

public class FileSystemService
{
    public void UploadImageToDb(string path, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("BlazorImages");
        var gridFS = new GridFSBucket(database);

        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            gridFS.UploadFromStream(fileName, fs);
        }
    }

    public string DownloadToLocal(string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("BlazorImages");
        var gridFS = new GridFSBucket(database);
        
        using (FileStream fs =
               new FileStream(
                   $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/Images/")}{fileName}",
                   FileMode.CreateNew))
        {
            gridFS.DownloadToStreamByName(fileName, fs);
        }

        return $"Images/{fileName}";
    }

    public List<string> UploadImages()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("BlazorImages");
        var collection = database.GetCollection<GridFSFileInfo>("Images");
        var images = collection.Find(new BsonDocument()).ToList();
        var nameImages = new List<string>();

        foreach (var img in images)
        {
            nameImages.Add(img.Filename);
        }

        return nameImages;
    }
}