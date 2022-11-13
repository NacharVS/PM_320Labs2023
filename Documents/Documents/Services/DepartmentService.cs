using Documents.Data;
using MongoDB.Driver;
using System.Linq;

namespace Documents.Services
{
    public class DepartmentService
    {
        public string[] GetDepartmentNames()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Department>("Departments");

            return collection.Find<Department>(x => true)
                            .ToEnumerable<Department>()
                            .Select(x => x.Name)
                            .ToArray();
        }

        public Department GetDepartmentByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Department>("Departments");

            return collection.Find(x => x.Name == name).FirstOrDefault();
        }

        public Department GetDepartmentById(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Department>("Departments");

            return collection.Find(x => x.Id == id).FirstOrDefault();
        }
    }
}
