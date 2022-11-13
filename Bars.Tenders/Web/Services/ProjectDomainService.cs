using Core.Entities.Projects;
using Core.Enums;
using DataProvider;
using MongoDB.Bson;

namespace Web.Services;

public class ProjectDomainService
{
    private readonly MongoProvider<BaseProject> _projectContext;

    public ProjectDomainService(MongoProvider<BaseProject> projectContext)
    {
        _projectContext = projectContext;
    }

    public async Task<BaseProject?> LoadProject(ObjectId id)
    {
        return await _projectContext.Load(id);
    }

    public async Task<IEnumerable<BaseProject?>> LoadProjects(ObjectId userId, IndustryType industryType = IndustryType.NotSpecified)
    {
        if (industryType != IndustryType.NotSpecified)
        {
            return (await _projectContext.LoadAll()).Where(x => x?.IndustryType == industryType);
        }
        
        return (await _projectContext.LoadAll()).Where(x =>
            x?.ArchitectId == userId
            || x?.BuilderId == userId
            || x?.CustomerId == userId);
    }

    public async Task SaveProject(BaseProject project)
    {
        await _projectContext.Save(project);
    }
}