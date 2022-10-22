using MongoDB.Driver;

namespace AuthorizationWebApp.Data;

public class UserService
{
    public User User;
    
    private static readonly MongoClient client = new MongoClient("mongodb://localhost");
    private static readonly IMongoDatabase db = client.GetDatabase("UsersDb");
    private readonly IMongoCollection<User> usersCollection = db.GetCollection<User>("Users");
    
    public void SaveUser(User user)
    {
        try
        {
            usersCollection.InsertOne(user);
        }
        catch (Exception e)
        {
        }
    }

    public User UserLogin(string Login)
    {
        try
        {
            User = usersCollection.Find(x => x.Login == Login).FirstOrDefault();
        }
        catch (Exception e)
        {
        }

        return User;
    }
}