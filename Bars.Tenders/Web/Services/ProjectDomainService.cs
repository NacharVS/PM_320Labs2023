using Core.Entities.Documents;
using Core.Entities.Projects;
using Core.Enums;
using DataProvider;
using MongoDB.Bson;

namespace Web.Services;

public class ProjectDomainService
{
    private readonly MongoProvider<BaseProject> _projectContext;
    private readonly MongoProvider<BaseDocument> _documentContext;
    private readonly DocumentDomainService _documentDomainService;

    public ProjectDomainService(MongoProvider<BaseProject> projectContext, MongoProvider<BaseDocument> documentContext, DocumentDomainService documentDomainService)
    {
        _projectContext = projectContext;
        _documentContext = documentContext;
        _documentDomainService = documentDomainService;
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
            || x?.BuilderId == userId);
    }

    public async Task SaveProject(BaseProject project)
    {
        await _projectContext.Save(project);
    }

    public async Task Delete(BaseProject entity)
    {
        await _projectContext.Delete(entity);

        var documents = (await _documentContext.LoadAll()).Where(x => x?.ProjectId == entity._id);
        foreach (var i in documents)
        {
            await _documentDomainService.Delete(i!);
        }
    }
}