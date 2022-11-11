using MongoDB.Driver;

namespace AuthorizationApp.Data
{
    public class UserService
    {
        private static MongoClient client = new MongoClient("mongodb://localhost");
        private static IMongoDatabase database = client.GetDatabase("Authorization");
        private IMongoCollection<User> users = database.GetCollection<User>("Users");
        public User CurrentUser { get; set; }

        public void AddUser(User user)
        {
            users.InsertOne(user);
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            var user = users.Find<User>(x => x.Login == login && x.Password == password).FirstOrDefault();
            return user;
        }

        public User GetUserByLogin(string login)
        {
            var user = users.Find<User>(x => x.Login == login).FirstOrDefault();
            return user;
        }
    }
}