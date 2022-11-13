using DocumentApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DocumentApp.Services;

public class ProjectService
{
    public Project CurrentProject { get; set; }

    public List<Project> GetProjects()
    {
        return DataBaseConnection.ProjectsCollection.Find(new BsonDocument()).ToList();
    }

    public bool CreateProject(Project project)
    {
        try
        {
            DataBaseConnection.ProjectsCollection.InsertOne(project);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Project GetProjectById(string projectId)
    {
        return DataBaseConnection.ProjectsCollection.Find(x => x.Id == projectId).FirstOrDefault();
    }

    public void UpdateProject(string projectId)
    {
        DataBaseConnection.ProjectsCollection.ReplaceOne(x => x.Id == projectId, CurrentProject);
    }
    
    public void SaveForm(Form form)
    {
        DataBaseConnection.FormsCollection.InsertOne(form);
    }
}