using MongoDB.Bson;
using MongoDB.Driver;

namespace DocumentApp.Models;

public class RoleService
{
    public List<Role> GetAllRoles()
    {
        return DataBaseConnection.RolesCollection.Find(new BsonDocument()).ToList();
    }
}