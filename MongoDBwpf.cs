using MongoDB.Driver;
using WPFcharacterictic.Core;
using WPFcharacterictic.Core.interfaces;

namespace MongoDBwpf
{
    public class MongoDBwpf<TEntity> where TEntity : IHaveName
    {
        public static void AddToDataBase(TEntity entity, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<TEntity>(collectionName);
            collection.InsertOne(entity);
        }

        public static TEntity FindByName(string name, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<TEntity>(collectionName);
            var newEntity = collection.Find(x => x.Name == name).FirstOrDefault();
            return newEntity;
        }

        public static void ReplaceByName(string name, TEntity entity, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<TEntity>(collectionName);
            collection.ReplaceOne(x => x.Name == name, entity);
        }

        public static List<TEntity> GetAll(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<TEntity>(collectionName);

            return collection.Find(_ => true).ToList();
        }
    }
}