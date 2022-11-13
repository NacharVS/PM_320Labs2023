using DocumentApp.Models;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DocumentApp;

public static class DataBaseConnection
{
    private static readonly MongoClient Client = new MongoClient("mongodb://localhost");
    private static readonly IMongoDatabase Db = Client.GetDatabase("DocumentsDb");
    public static readonly IMongoCollection<User> UsersCollection = Db.GetCollection<User>("Users");
    public static readonly IMongoCollection<Document> DocumentsCollection = Db.GetCollection<Document>("Documents");
    public static readonly IMongoCollection<Form> FormsCollection = Db.GetCollection<Form>("Forms");
    public static readonly IMongoCollection<Document> DesignerDocumentsCollection = Db.GetCollection<Document>("DesignerDocuments");
    public static readonly IMongoCollection<Role> RolesCollection = Db.GetCollection<Role>("Roles");
    public static readonly IMongoCollection<Project> ProjectsCollection = Db.GetCollection<Project>("Projects");
    public static readonly GridFSBucket? GridFs = new GridFSBucket(DataBaseConnection.Db);
}