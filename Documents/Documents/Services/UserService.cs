using Documents.Data;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Documents.Services
{
    public class UserService
    {
        public User CurrentUser;

        public UserService()
        {
            BsonClassMap.RegisterClassMap<User>();
            BsonClassMap.RegisterClassMap<Customer>();
            BsonClassMap.RegisterClassMap<Builder>();
            BsonClassMap.RegisterClassMap<Architect>();
        }

        public void InsertUser(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            collection.InsertOne(user);
        }

        public bool IsUserExist(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            return collection.Find<User>(x => x.Login == login).FirstOrDefault() != null;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            return collection.Find<User>(x => x.Login == login && x.Password == password).FirstOrDefault();
        }

        public void UpdateUser(User user, string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            collection.ReplaceOne(x => x.Login == login, user);
        }
    }
}