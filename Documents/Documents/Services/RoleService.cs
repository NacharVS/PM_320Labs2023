using Documents.Data;
using MongoDB.Driver;
using System.Linq;

namespace Documents.Services
{
    public class RoleService
    {
        public string[] GetRoleNames()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Role>("Roles");

            return collection.Find<Role>(x => true)
                            .ToEnumerable<Role>()
                            .Select(x => x.Name)
                            .ToArray();
        }

        public Role GetRoleByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Role>("Roles");

            return collection.Find(x => x.Name == name).FirstOrDefault();
        }

        public Role GetRoleById(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Role>("Roles");

            return collection.Find(x => x.Id == id).FirstOrDefault();
        }
    }
}