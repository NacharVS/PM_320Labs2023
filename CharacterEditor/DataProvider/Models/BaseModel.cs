using DataProvider.Domain;
using Editor.Core.Characters.interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider.Models;

public abstract class BaseModel : IHaveId, IHaveName
{
    [BsonId]
    public string Id { get; set; } = null!;

    public string? Name { get; set; }
}