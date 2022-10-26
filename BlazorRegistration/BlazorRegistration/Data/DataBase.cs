
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazorRegistration.Data;
    public class DataBase
    {
        private LocalStorageService _localStorageService;
        private DataBase(LocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public static void AddToDataBase(User user)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("UsersList");
            collection.InsertOne(user);
        }
        public static User FindByLogin(string login)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("UsersList");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();

            return user;
        }
        private void SaveUser(User user)
        {
            _localStorageService.SetAsync<User>(user.Login, user);
        }
    }