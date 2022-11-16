using Documents.Data;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Documents.Services
{
    public class ProjectService
    {
        public Project CurrentProject { get; set; }

        public ProjectService()
        {
            BsonClassMap.RegisterClassMap<Project>();
            BsonClassMap.RegisterClassMap<DocumentInfo>();
            BsonClassMap.RegisterClassMap<FormInfo>();
            BsonClassMap.RegisterClassMap<GasProject>();
            BsonClassMap.RegisterClassMap<WaterSupplyProject>();
        }

        public List<string> GetProjectsByDepartment(string department_id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Project>("Projects");

            return collection.Find<Project>(x => x.Department_ID == department_id)
                            .ToEnumerable<Project>()
                            .Select(x => x.Name)
                            .ToList<string>();
        }

        public List<string> GetProjectsByArchitect(string architect_id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Project>("Projects");

            return collection.Find<Project>(x => x.Architect == architect_id)
                            .ToEnumerable<Project>()
                            .Select(x => x.Name)
                            .ToList<string>();
        }

        public List<string> GetProjectsByBuider(string builder_id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Project>("Projects");

            return collection.Find<Project>(x => x.Builder == builder_id)
                            .ToEnumerable<Project>()
                            .Select(x => x.Name)
                            .ToList<string>();
        }

        public Project GetProjectByName(string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Project>("Projects");

            return collection.Find<Project>(x => x.Name == name).FirstOrDefault();
        }

        public void InsertProject(Project project)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Project>("Projects");

            collection.InsertOne(project);
        }

        public void UpdateProject(Project project, string name)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");
            var collection = connection.GetCollection<Project>("Projects");

            collection.ReplaceOne(x => x.Name == name, project);
        }
    }
}