using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider.Domain;

public interface IHaveId
{
    [BsonId]
    public string Id { get; set; }
}