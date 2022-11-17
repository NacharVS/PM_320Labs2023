using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using ServiceApp.Data;

namespace ServiceApp.Services;

public class FileSystemService
{
    //UploadAsync
    public async Task UploadWaterDocumentToDbAsync(Stream stream, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("WaterDocumentation");
        var gridFS = new GridFSBucket(database);
        
        await gridFS.UploadFromStreamAsync(fileName, stream);
    }
    public async Task UploadGasDocumentToDbAsync(Stream stream, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("GasDocumentation");
        var gridFS = new GridFSBucket(database);
        
        await gridFS.UploadFromStreamAsync(fileName, stream);
    }
    
    public async Task UploadCustomerDocumentationToDbAsync(Project project)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("CustomerDocumentation");
        var collection = database.GetCollection<Project>("Documents");
        collection.InsertOne(project);
    }
    public async Task UploadDesignerDocumentToDbAsync(Stream stream, string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("DesignerDocumentation");
        var gridFS = new GridFSBucket(database);
        
        await gridFS.UploadFromStreamAsync(fileName, stream);
    }
    //Download
    public string DownloadWaterDocToLocal(string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("WaterDocumentation");
        var gridFS = new GridFSBucket(database);
        
        using (FileStream fs =
               new FileStream(
                   $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/WaterDocuments/")}" +
                   $"{fileName}",
                   FileMode.OpenOrCreate))
        {
            gridFS.DownloadToStreamByName(fileName, fs);
        }

        return $"Doc/{fileName}";
    }
    
    public string DownloadGasDocToLocal(string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("GasDocumentation");
        var gridFS = new GridFSBucket(database);
        
        using (FileStream fs =
               new FileStream(
                   $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/GasDocuments/")}" +
                   $"{fileName}",
                   FileMode.OpenOrCreate))
        {
            gridFS.DownloadToStreamByName(fileName, fs);
        }

        return $"Doc/{fileName}";
    }
    public string DownloadDesignerDocToLocal(string fileName)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("DesignerDocumentation");
        var gridFS = new GridFSBucket(database);
        
        using (FileStream fs =
               new FileStream(
                   $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/DesignerDocuments/")}" +
                   $"{fileName}",
                   FileMode.OpenOrCreate))
        {
            gridFS.DownloadToStreamByName(fileName, fs);
        }

        return $"Doc/{fileName}";
    }
    //Upload
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
    public List<string> UploadWaterDocuments()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("WaterDocumentation");
        var collection = database.GetCollection<GridFSFileInfo>("fs.files");
        var documents = collection.Find(x => true).ToList();
        var nameDocuments = new List<string>();

        foreach (var doc in documents)
        {
            nameDocuments.Add(doc.Filename);
        }

        return nameDocuments;
    }
    public List<string> UploadGasDocuments()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("GasDocumentation");
        var collection = database.GetCollection<GridFSFileInfo>("fs.files");
        var documents = collection.Find(x => true).ToList();
        var nameDocuments = new List<string>();

        foreach (var doc in documents)
        {
            nameDocuments.Add(doc.Filename);
        }

        return nameDocuments;
    }
    public List<string> UploadDesignerDocuments()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("DesignerDocumentation");
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