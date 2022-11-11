using MongoDB.Bson;
using MongoDB.Driver;
using ServiceApp.Data;
namespace ServiceApp.Services;
public class DataBase
{
    public Worker? CurrentUser { get; set; }
        
    public void AddToDataBase(Worker user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Worker>("UsersList");
        collection.InsertOne(user);
    }
    public Worker FindByLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Worker>("UsersList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
}