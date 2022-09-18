using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataProvider
{
    public class MongoConnection<TEntity>
    {
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<TEntity> Collection { get; set; }

        public MongoConnection(string connectionString, string dataBaseName, string collectionName)
        {
            Database = new MongoClient(connectionString).GetDatabase(dataBaseName);
            Collection = Database.GetCollection<TEntity>(collectionName);
        }
    }
}
