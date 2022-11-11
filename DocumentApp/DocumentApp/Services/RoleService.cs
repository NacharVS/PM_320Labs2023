using MongoDB.Bson;
using MongoDB.Driver;

namespace DocumentApp.Models;

public class RoleService
{
    public List<Role> GetAllRoles()
    {
        return DataBaseConnection.RolesCollection.Find(new BsonDocument()).ToList();
    }

    public Role GetRoleByName(string roleName)
    {
        return DataBaseConnection.RolesCollection.Find(x => x.Name == roleName).FirstOrDefault();
    }
    public string? GetRoleNameById(string? id)
    {
        return DataBaseConnection.RolesCollection.Find(x => x.Id == id).FirstOrDefault().Name;
    }
}