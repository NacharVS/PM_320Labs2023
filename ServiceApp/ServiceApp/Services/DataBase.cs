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

    public Project? CurrentProject { get; set; }
    //Add
    public void AddCustomerToDataBase(Customer user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Customer>("CustomerList");
        collection.InsertOne(user);
    }
    public void AddDesignerToDataBase(Designer user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("DesignerList");
        collection.InsertOne(user);
    }
    public void AddDeveloperToDataBase(Developer user)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("DeveloperList");
        collection.InsertOne(user);
    }
    //Find
    public Customer FindByCustomerLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Customer>("CustomerList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
    
    public Designer FindByDesignerLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("DesignerList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
    
    public Developer FindByDeveloperLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("DeveloperList");
        var user = collection.Find(x => x.Login == login).FirstOrDefault();

        return user;
    }
    //Replace
    public void ReplaceCustomerByName(string login, Customer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Customer>("CustomerList");
        collection.ReplaceOne(x => x.Login == login, user);
    }
    public void ReplaceDesignerByName(string login, Designer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("DesignerList");
        collection.ReplaceOne(x => x.Login == login, user);
    }
    public void ReplaceDeveloperByName(string login, Developer user)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("DeveloperList");
        collection.ReplaceOne(x => x.Login == login, user);
    }
    //Project
    public List<Project> FindProjByDesignerLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Project>("DesignerList");
        var projects = collection.Find(x => x.Designer == login).ToList();

        return projects;
    }
    
    public List<Project> FindProjByDeveloperLogin(string login)
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Project>("DeveloperList");
        var projects = collection.Find(x => x.Developer == login).ToList();

        return projects;
    }
    
    //ImportAll
    public List<Designer> ImportAllDesigner()
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Designer>("DesignerList");
        var list = collection.Find(new BsonDocument()).ToList();
        return list;
    }
    
    public List<Developer> ImportAllDeveloper()
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database = client.GetDatabase("ServiceDatabase");
        var collection = database.GetCollection<Developer>("DeveloperList");
        var list = collection.Find(new BsonDocument()).ToList();
        return list;
    }
}