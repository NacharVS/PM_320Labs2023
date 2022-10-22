using MongoDB.Driver;

namespace Authorization.Module
{
    public static class MongoDB
    {
        public static void AddToDataBase(string collectionName, User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<User>(collectionName);
            collection.InsertOne(user);
        }

        public static User FindByName(string name, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<User>(collectionName);
            var newEntity = collection.Find(x => x.Name == name).FirstOrDefault();
            return newEntity;
        }
    }
}
