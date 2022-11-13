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
    public void AddToDataBase(Customer user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Customer>("UsersList");
        collection.InsertOne(user);
    }
    public void AddToDataBase(Designer user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("UsersList");
        collection.InsertOne(user);
    }
    public void AddToDataBase(Developer user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("UsersList");
        collection.InsertOne(user);
    }
    public Worker FindByWorkerLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Worker>("UsersList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
    public Customer FindByCustomerLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Customer>("UsersList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
    
    public Designer FindByDesignLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("UsersList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
    
    public Developer FindByDeveloperLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("UsersList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
}