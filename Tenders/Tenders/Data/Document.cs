using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tenders.Data;

public class Document
{
    [BsonId] public ObjectId Id;
    [BsonIgnoreIfDefault] public string Name;
    [BsonIgnoreIfDefault] public bool IsRequired;
    [BsonIgnoreIfDefault] public bool IsApproved;
    [BsonIgnoreIfDefault] public byte[]? data;
    [BsonIgnoreIfDefault] public string FileName;
    [BsonIgnoreIfDefault] public string FileExtension;

    public Document(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}