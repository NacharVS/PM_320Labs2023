using MongoDB.Driver;
using ServiceApp.Data;

namespace ServiceApp.Services
{
    public class DBConnection
    {
        public static void AddToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            collection.InsertOne(user);
        }

        public static User FindByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<User>("CollectionOfUsers");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }

        public static void AddToDataBaseCustomer(Customer user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Customer>("CollectionOfCustomers");
            collection.InsertOne(user);
        }

        public static Customer FindByLoginCustomer(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Customer>("CollectionOfCustomers");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }

        public static void AddToDataBaseDesigner(Designer user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Designer>("CollectionOfDesigners");
            collection.InsertOne(user);
        }

        public static Designer FindByLoginDesigner(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Designer>("CollectionOfDesigners");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }

        public static void AddToDataBaseDeveloper(Developer user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Developer>("CollectionOfDeveloper");
            collection.InsertOne(user);
        }

        public static Developer FindByLoginDeveloper(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Developer>("CollectionOfDeveloper");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }
    }
}
