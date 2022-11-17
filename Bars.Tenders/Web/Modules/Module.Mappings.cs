using Core.Entities.Documents;
using Core.Entities.Users;
using MongoDB.Bson.Serialization;

namespace Web.Modules;

public partial class Module
{
    private void MapEntities()
    {
        BsonClassMap.RegisterClassMap<BaseUser>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });

        BsonClassMap.RegisterClassMap<Customer>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });

        BsonClassMap.RegisterClassMap<Builder>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });

        BsonClassMap.RegisterClassMap<Architect>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });
        
        BsonClassMap.RegisterClassMap<BaseDocument>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
        });
    }
}