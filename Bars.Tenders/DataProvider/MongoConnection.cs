using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataProvider
{
    public class MongoConnection<TEntity>
    {
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<TEntity> Collection { get; set; }

        public MongoConnection(IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:MongoConnection"];
            var mongoDb = configuration["ConnectionStrings:MongoDatabase"];
            var collectionName = typeof(TEntity).Name;
            
            Database = new MongoClient(connectionString).GetDatabase(mongoDb);
            Collection = Database.GetCollection<TEntity>(collectionName);
        }
    }
}
