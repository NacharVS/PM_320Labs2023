using MongoDB.Driver;

namespace BlazorReg.Data
{
    public class DataBase
    {
        public static void AddToDataBase(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("UsersList");
            collection.InsertOne(user);
        }
        public static User FindByName(string name)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("UsersList");
            var user = collection.Find(x => x.Name == name).FirstOrDefault();

            return user;
        }
    }
}