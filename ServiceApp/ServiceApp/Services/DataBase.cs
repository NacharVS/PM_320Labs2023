using MongoDB.Bson;
using MongoDB.Driver;
using ServiceApp.Data;

namespace ServiceApp.Services;
public class DataBase
{
    public Worker? CurrentUser { get; set; }
    public Customer? CurrentCustomer { get; set; }
    public Designer? CurrentDesigner { get; set; }
    public Developer? CurrentDeveloper { get; set; }
    //Add
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
    //Find
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
    //Replace
    public void ReplaceCustomerByName(string login, Customer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Customer>("UsersList");
        collection.ReplaceOne(x => x.Login == login, user);
    }
    public void ReplaceDesignerByName(string login, Designer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("UsersList");
        collection.ReplaceOne(x => x.Login == login, user);
    }
    public void ReplaceDeveloperByName(string login, Developer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("UsersList");
        collection.ReplaceOne(x => x.Login == login, user);
    }
}