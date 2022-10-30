
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazorRegistration.Data;
    public class DataBase
    {
        public User? CurrentUser { get; set; }
        
        public void AddToDataBase(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("UsersList");
            collection.InsertOne(user);
        }
        public User FindByLogin(string login)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("UsersList");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();

            return user;
        }
    }