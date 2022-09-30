using CharacterCreator.Core;
using MongoDB.Driver;

namespace CharacterCreator.Data;

public class DbConnection<T>
{
    public IMongoDatabase Database { get; set; }
    public IMongoCollection<T> Collection { get; set; }

    public DbConnection(string connectionString, string dataBaseName, string collectionName)
    {
        Database = new MongoClient(connectionString).GetDatabase(dataBaseName);
        Collection = Database.GetCollection<T>(collectionName);
    }
}