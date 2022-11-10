using DocumentApp.Models;
using MongoDB.Driver;

namespace DocumentApp;

public static class DataBaseConnection
{
    private static readonly MongoClient Client = new MongoClient("mongodb://localhost");
    private static readonly IMongoDatabase Db = Client.GetDatabase("DocumentsDb");
    public static readonly IMongoCollection<User> UsersCollection = Db.GetCollection<User>("Users");
    //public static readonly IMongoCollection<User> DocumentsCollection = Db.GetCollection<User>("Documents");
    public static readonly IMongoCollection<Role> RolesCollection = Db.GetCollection<Role>("Roles");
    //public static readonly IMongoCollection<User> ProjectsCollection = Db.GetCollection<User>("Project");
}