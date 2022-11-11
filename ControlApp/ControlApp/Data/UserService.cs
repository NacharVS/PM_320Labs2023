using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ControlApp.Data
{
    public class UserService
    {
        public User CurrentUser { get; set; }
        private IMongoCollection<User> _users; 

        public UserService(string? connectionClient, string? databaseStr)
        {
            var client = new MongoClient(connectionClient);
            var database = client.GetDatabase(databaseStr);

            _users = database.GetCollection<User>("Users");
        }

        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }

        public User GetUserByLogin(string login, string password)
        {
            return _users.Find<User>(x => x.Login == login && x.Password == password).FirstOrDefault();
        }

        public User GetUser(string login)
        {
            return _users.Find<User>(x => x.Login == login).FirstOrDefault();
        }
    }
}