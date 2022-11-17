using Core.Entities.Documents;
using Core.Entities.Users;
using Core.Enums;
using DataProvider;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using Web.Services;

namespace Web.Services;

public class DocumentDomainService
{
    private readonly MongoProvider<BaseDocument> _baseDocumentContext;
    private readonly MongoProvider<GasificationDocument> _gasDocumentContext;
    private readonly MongoProvider<WaterSupplyDocument> _waterDocumentContext;
    private readonly IGridFSBucket _gridFs;

    public DocumentDomainService(MongoProvider<BaseDocument> baseDocumentContext,
        MongoProvider<GasificationDocument> gasDocumentContext, MongoProvider<WaterSupplyDocument> waterDocumentContext)
    {
        _baseDocumentContext = baseDocumentContext;
        _gasDocumentContext = gasDocumentContext;
        _waterDocumentContext = waterDocumentContext;
        _gridFs = new GridFSBucket(_baseDocumentContext.GetDatabase());
    }

    public async Task<BaseDocument?> LoadDocument(ObjectId id, IndustryType industryType = IndustryType.NotSpecified,
        bool asBaseCollection = false)
    {
        if (industryType == IndustryType.Gasification)
        {
            return await _gasDocumentContext.Load(id, asBaseCollection);
        }

        if (industryType == IndustryType.WaterSupply)
        {
            return await _waterDocumentContext.Load(id, asBaseCollection);
        }

        return await _baseDocumentContext.Load(id, asBaseCollection);
    }

    public async Task<IEnumerable<BaseDocument?>> LoadProjectDocuments(ObjectId projectId, BaseUser currentUser,
        IndustryType industryType = IndustryType.NotSpecified, bool asBaseCollection = false)
    {
        if (industryType == IndustryType.Gasification)
        {
            return (await _gasDocumentContext.LoadAll(asBaseCollection)).Where(x => x?.ProjectId == projectId)
                .Where(x => currentUser?.Role == UserRole.Customer || x?.OwnerId == currentUser?._id);
        }

        if (industryType == IndustryType.WaterSupply)
        {
            return (await _waterDocumentContext.LoadAll(asBaseCollection)).Where(x => x?.ProjectId == projectId)
                .Where(x => currentUser?.Role == UserRole.Customer || x?.OwnerId == currentUser?._id);
        }

        return (await _baseDocumentContext.LoadAll(asBaseCollection)).Where(x => x?.ProjectId == projectId)
            .Where(x => currentUser?.Role == UserRole.Customer || x?.OwnerId == currentUser?._id);
    }

    public async Task SaveGasificationDocument(GasificationDocument entity, bool asBaseCollection = false)
    {
        await _gasDocumentContext.Save(entity, asBaseCollection);
    }

    public async Task SaveWaterSupplyDocument(WaterSupplyDocument entity, bool asBaseCollection = false)
    {
        await _waterDocumentContext.Save(entity, asBaseCollection);
    }

    /// <summary>
    /// Save document file and return it's id
    /// </summary>
    /// <returns></returns>
    public async Task<ObjectId> SaveFile(string name, Stream ms)
    {
        return await _gridFs.UploadFromStreamAsync(name, ms);
    }

    public async Task DownloadFile(ObjectId fileId, FileStream stream)
    {
        await _gridFs.DownloadToStreamAsync(fileId, stream);
    }

    public async Task Delete(BaseDocument entity, bool asBaseCollection = false)
    {
        await _baseDocumentContext.Delete(entity);
        await _gridFs.DeleteAsync(entity.FileId);
    }
    
}