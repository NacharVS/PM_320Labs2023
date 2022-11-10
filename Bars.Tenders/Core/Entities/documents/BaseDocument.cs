using MongoDB.Bson;

namespace Core.Entities.documents;

public class BaseDocument : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAccepted { get; set; }
    public ObjectId OwnerId { get; set; }
    public ObjectId FileId { get; set; }
}