using Documents.Data;
using System.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;

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

        public List<User> GetUsersNamesByRole(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            return collection.Find<User>(x => x.Role_ID == id).ToList();
        }

        public User GetUserByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            return collection.Find<User>(x => x.ToString() == name).FirstOrDefault<User>();
        }

        public User GetUserById(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<User>("Users");

            return collection.Find<User>(x => x.Id == id).FirstOrDefault<User>();
        }
    }
}