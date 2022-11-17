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

    public void InsertRoles()
    {
        DataBaseConnection.RolesCollection.InsertOne(new Role()
        {
            Name = "Застройщик",
            Id = "636d3987fa5a3023d2857cbc"
        });
        DataBaseConnection.RolesCollection.InsertOne(new Role()
        {
            Name = "Проектировщик",
            Id = "636d3987fa5a3023d2857cbe"
        });
        DataBaseConnection.RolesCollection.InsertOne(new Role()
        {
            Name = "Заказчик",
            Id = "636d3987fa5a3023d2857cbd"
        });
    }
}