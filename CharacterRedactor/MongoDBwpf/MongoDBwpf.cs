using MongoDB.Driver;
using WPFcharacterictic.Core;

namespace MongoDBwpf
{
    public class MongoDBwpf
    {
        public static void AddToDataBase(Entity entity)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<Entity>("Units");
            collection.InsertOne(entity);
        }

        public static Entity FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<Entity>("Units");
            var newEntity = collection.Find(x => x.Name == name).FirstOrDefault();
            return newEntity;
        }

        public static void ReplaceByName(string name, Entity entity)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ktits");
            var collection = database.GetCollection<Entity>("Units");
            collection.ReplaceOne(x => x.Name == name, entity);
        }
    }
}