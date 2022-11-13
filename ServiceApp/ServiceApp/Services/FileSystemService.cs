using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace ServiceApp.Services;

public class FileSystemService
{
    public async Task UploadDocumentToDbAsync(Stream stream, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Documentation");
        var gridFS = new GridFSBucket(database);
        
        await gridFS.UploadFromStreamAsync(fileName, stream);
    }

    public string DownloadToLocal(string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Documentation");
        var gridFS = new GridFSBucket(database);
        
        using (FileStream fs =
               new FileStream(
                   $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/Documents/")}" +
                   $"{fileName}",
                   FileMode.OpenOrCreate))
        {
            gridFS.DownloadToStreamByName(fileName, fs);
        }

        return $"Doc/{fileName}";
    }

    public List<string> UploadDocuments()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Documentation");
        var collection = database.GetCollection<GridFSFileInfo>("fs.files");
        var documents = collection.Find(x => true).ToList();
        var nameDocuments = new List<string>();

        foreach (var doc in documents)
        {
            nameDocuments.Add(doc.Filename);
        }

        return nameDocuments;
    }
}