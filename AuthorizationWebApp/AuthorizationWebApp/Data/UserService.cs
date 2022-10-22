using MongoDB.Driver;

namespace AuthorizationWebApp.Data;

public class UserService
{
    public User currentUser = new User();
    
    private static readonly MongoClient client = new MongoClient("mongodb://localhost");
    private static readonly IMongoDatabase db = client.GetDatabase("UsersDb");
    private readonly IMongoCollection<User> usersCollection = db.GetCollection<User>("Users");
    
    public bool SaveUser(User user)
    {
        try
        {
            usersCollection.InsertOne(user);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public User UserLogin(string Login)
    {
        try
        {
            currentUser = usersCollection.Find(x => x.Login == Login).FirstOrDefault();
        }
        catch (Exception e)
        {
        }

        return currentUser;
    }
}