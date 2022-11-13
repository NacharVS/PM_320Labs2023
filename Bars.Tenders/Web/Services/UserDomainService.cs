using Core.Entities.Projects;
using Core.Entities.Users;
using Core.Enums;
using DataProvider;
using MongoDB.Bson;

namespace Web.Services;

public class UserDomainService
{
    private readonly MongoProvider<BaseUser> _userContext;
    private readonly MongoProvider<Customer> _customerContext;
    private readonly MongoProvider<Builder> _builderContext;
    private readonly MongoProvider<Architect> _architectContext;

    public UserDomainService(MongoProvider<BaseUser> userContext,
        MongoProvider<Customer> customerContext, MongoProvider<Builder> builderContext,
        MongoProvider<Architect> architectContext)
    {
        _userContext = userContext;
        _customerContext = customerContext;
        _builderContext = builderContext;
        _architectContext = architectContext;
    }

    public async Task<BaseUser?> LoadUser(ObjectId id, UserRole role,  bool asBaseCollection = false)
    {
        switch (role)
        {
            case UserRole.Customer:
                return await _customerContext.Load(id, asBaseCollection);
            case UserRole.Builder:
                return await _builderContext.Load(id, asBaseCollection);
            case UserRole.Architect:
                return await _architectContext.Load(id, asBaseCollection);
            default:
                throw new Exception("Role is not specified!");
        }
    }

    public async Task<IEnumerable<Builder?>> LoadBuilders(bool asBaseCollection = false)
    {
        return (await _builderContext.LoadAll(true)).Where(x => x?.Role == UserRole.Builder);
    }
    
    public async Task<IEnumerable<Architect?>> LoadArchitects(bool asBaseCollection = false)
    {
        return (await _architectContext.LoadAll(true)).Where(x => x?.Role == UserRole.Architect);
    }

    public async Task SaveUser(BaseUser entity, bool asBaseCollection = false)
    {
        switch (entity.Role)
        {
            case UserRole.Customer:
                await _customerContext.Save(entity as Customer ?? new Customer(), asBaseCollection);
                break;
            case UserRole.Builder:
                await _builderContext.Save(entity as Builder ?? new Builder(), asBaseCollection);
                break;
            case UserRole.Architect:
                await _architectContext.Save(entity as Architect ?? new Architect(), asBaseCollection);
                break;
            default:
                throw new Exception("Role is not specified!");
        }
    }
}