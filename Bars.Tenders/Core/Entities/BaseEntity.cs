using Core.Entities.interfaces;
using MongoDB.Bson;

namespace Core.Entities;

public class BaseEntity : IHaveId
{
    public ObjectId _id { get; set; }
}