using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using Tenders.Data.Users;

namespace Tenders.Data.Services;

public class MongoConnectionService
{
    private static IMongoDatabase database = new MongoClient("mongodb://localhost").GetDatabase("Tenders");

    public static UserModel? FindUser(string login, string password)
    {
        var collection = database.GetCollection<UserModel>("Users");
        var user = collection.Find(x => x.Login == login && x.Password == password).FirstOrDefault();

        return user;
    }

    public static UserModel? FindByLogin(string login)
    {
        var collection = database.GetCollection<UserModel>("Users");
        return collection.Find(x => x.Login == login).FirstOrDefault();
    }

    public static void AddToDb(User? user)
    {
        var collection = database.GetCollection<UserModel>("Users");
        var model = new UserModel(user);
        collection.InsertOne(model);
        user.Id = model.Id;
    }

    public void ReplaceUser(User user)
    {
        var collection = database.GetCollection<UserModel>("Users");
        var model = new UserModel(user);
        collection.ReplaceOne(x => x.Login == model.Login, model);
    }

    public List<UserModel> GetDevelopers()
    {
        var collection = database.GetCollection<UserModel>("Users");
        var filter = new BsonDocument("Role", 3);

        return (collection.Find(filter).ToList());
    }

    public List<UserModel> GetDesigners()
    {
        var collection = database.GetCollection<UserModel>("Users");
        var filter = new BsonDocument("Role", 2);

        return collection.Find(filter).ToList();
    }
    
    public void AddToDb(Project? project)
    {
        var collection = database.GetCollection<Project>("Projects");
        collection.InsertOne(project);
    }

    public List<Project> GetProjects()
    {
        var collection = database.GetCollection<Project>("Projects");
        return collection.Find(new BsonDocument()).ToList();
    }

    public async Task UploadFileToDb(IBrowserFile file, Document document, Stream stream)
    {
        var gridFS = new GridFSBucket(database);
        await gridFS.UploadFromStreamAsync(file.Name, stream);
        document.FileName = file.Name;
        document.FileExtension =  file.Name.Split('.')[^1];
        document.data = GetByteArrayFromFile(file.Name);
    }
    
    public byte[] GetByteArrayFromFile(string fileName)
    {
        byte[] byteArray;
        var gridFS = new GridFSBucket(database);
        try
        {
            byteArray = gridFS.DownloadAsBytesByName(fileName);
        }
        catch
        {
            byteArray = null;
        }
        return byteArray;
    }

    public void DownloadFile(Document document)
    {
        File.WriteAllBytes($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{document.Name}.{document.FileExtension}", document.data);
    }

    public void SaveProject(Project project)
    {
        var collection = database.GetCollection<Project>("Projects");
        collection.ReplaceOne(x => x.Id == project.Id, project);
    }
}