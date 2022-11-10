using MongoDB.Driver;
using ServiceApp.Data;

namespace ServiceApp.Services
{
    public class DBConnection
    {
        public static void AddToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            collection.InsertOne(user);
        }

        public static User FindByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Galieva");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }
    }
}
