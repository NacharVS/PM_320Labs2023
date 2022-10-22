using Core.Entities;
using MongoDB.Driver;

namespace Core.DataProvider;

public static class Database
{
    private static readonly MongoClient Client = new MongoClient("mongodb://localhost");
    private static readonly IMongoDatabase MongoDatabase = Client.GetDatabase("UsersDatabase");

    public static async Task SaveUser(User user)
    {
        await MongoDatabase.GetCollection<User>("User").InsertOneAsync(user);
    }

    public static async Task<User?> GetUser(string login)
    {
        var result = await MongoDatabase.GetCollection<User>("User")
            .FindAsync(x => x.Login == login);

        await result.MoveNextAsync();
        return result.Current?.FirstOrDefault();
    }
}