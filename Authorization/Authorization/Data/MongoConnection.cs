using MongoDB.Bson;
using MongoDB.Driver;

namespace Authorization.Data;


public static class MongoConnection
{
    public static IMongoCollection<User> GetCollection()
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("Authorization");
        var collection = database.GetCollection<User>("Users");
        return collection;
    }

    public static User Login(string login, string password)
    {
        var collection = GetCollection();
        var character = collection.Find(x => x.Login == login && x.Password == password).FirstOrDefault();

        return character;
    }

    public static void AddToDb(User user)
    {
        var collection = GetCollection();
        collection.InsertOne(user);
    }

    public static List<User> GetOnlineUsers()
    {
        var collection = GetCollection();
        var filter = new BsonDocument("IsOnline", true);
        return (collection.Find(filter).ToList());
    }
}