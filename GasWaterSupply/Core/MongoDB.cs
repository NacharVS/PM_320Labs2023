using MongoDB.Driver;
using Core.Interfaces;
using MongoDB.Bson;

namespace MongoDB
{
    public class MongoDB<TEntity> where TEntity : IPrimaryData
    {
        MongoClient client;
        IMongoDatabase database;

        public MongoDB() 
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("GasWaterSupply");
        } 

        public static void AddToDataBase(TEntity entity, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GasWaterSupply");
            var collection = database.GetCollection<TEntity>(collectionName);
            collection.InsertOne(entity);
        }

        public static TEntity FindById(ObjectId id, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GasWaterSupply");
            var collection = database.GetCollection<TEntity>(collectionName);
            var newEntity = collection.Find(x => x.Id == id).FirstOrDefault();
            return newEntity;
        }
        public static TEntity FindByLogin(string login, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GasWaterSupply");
            var collection = database.GetCollection<TEntity>(collectionName);
            var newEntity = collection.Find(x => x.Login == login).FirstOrDefault();
            return newEntity;
        }

        public static void ReplaceByName(ObjectId id, TEntity entity, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GasWaterSupply");
            var collection = database.GetCollection<TEntity>(collectionName);
            collection.ReplaceOne(x => x.Id == id, entity);
        }

        public static List<TEntity> GetAll(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GasWaterSupply");
            var collection = database.GetCollection<TEntity>(collectionName);

            return collection.Find(_ => true).ToList();
        }
    }
}