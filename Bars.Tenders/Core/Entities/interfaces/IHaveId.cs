using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.interfaces;

public interface IHaveId
{
    [BsonId]
    public ObjectId _id { get; set; }
}