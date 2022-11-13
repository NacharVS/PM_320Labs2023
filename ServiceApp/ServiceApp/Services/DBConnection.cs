using MongoDB.Driver;
using MongoDB.Bson;
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

        public static void ReplaceCustomer(Customer customer)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var filter = new BsonDocument("Login", customer.Login);
            var collection = database.GetCollection<Customer>("CollectionOfCustomers");
            collection.ReplaceOne(filter, customer);
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

        public static void ReplaceDesigner(Designer designer)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var filter = new BsonDocument("Login", designer.Login);
            var collection = database.GetCollection<Designer>("CollectionOfDesigners");
            collection.ReplaceOne(filter, designer);
        }

        public static List<Designer> ImportAllDesigner()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Designer>("CollectionOfDesigners");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
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

        public static void ReplaceDeveloper(Developer developer)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var filter = new BsonDocument("Login", developer.Login);
            var collection = database.GetCollection<Developer>("CollectionOfDeveloper");
            collection.ReplaceOne(filter, developer);
        }

        public static List<Developer> ImportAllDevelopers()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Developer>("CollectionOfDeveloper");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public static void AddToDataBaseProjectG(Project project)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Project>("CollectionOfProjectsGas");
            collection.InsertOne(project);
        }

        public static void AddToDataBaseProjectW(Project project)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Project>("CollectionOfProjectsWater");
            collection.InsertOne(project);
        }

        public static List<Project> ImportAllProjectW()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Project>("CollectionOfProjectsWater");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public static List<Project> ImportAllProjectG()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Project>("CollectionOfProjectsGas");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public static List<Project> FindByLoginDevelopersProj(string loginOfDev)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Project>("CollectionOfProjectsGas");
            var collectionTwo = database.GetCollection<Project>("CollectionOfProjectsWater");
            var first = collection.Find(x => x.Developer == loginOfDev).ToList();
            var second = collectionTwo.Find(x => x.Developer == loginOfDev).ToList();
            foreach (var doc in second)
            {
                first.Add(doc);
            }
            return first;
        }

        public static List<Project> FindByLoginDesignersProj(string loginOfDes)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var collection = database.GetCollection<Project>("CollectionOfProjectsGas");
            var collectionTwo = database.GetCollection<Project>("CollectionOfProjectsWater");
            var first = collection.Find(x => x.Developer == loginOfDes).ToList();
            var second = collectionTwo.Find(x => x.Developer == loginOfDes).ToList();
            foreach (var doc in second)
            {
                first.Add(doc);
            }
            return first;
        }

        public static void ReplaceGas(Project project)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var filter = new BsonDocument("_id", project.Id);
            var collection = database.GetCollection<Project>("CollectionOfProjectsGas");
            collection.ReplaceOne(filter, project);
        }

        public static void ReplaceWater(Project project)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GalievaProject");
            var filter = new BsonDocument("_id", project.Id);
            var collection = database.GetCollection<Project>("CollectionOfProjectsWater");
            collection.ReplaceOne(filter, project);
        }
    }
}
