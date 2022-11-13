using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Project
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonIgnoreIfNull] 
    public string? ProjectName { get; set; }
    
    [BsonIgnoreIfNull] 
    public string? ProjectDepartment { get; set; }
    
    [BsonIgnoreIfNull] 
    public string? CustomerId { get; set; }
    
    [BsonIgnoreIfNull] 
    public string? DesignerId { get; set; }
    
    [BsonIgnoreIfNull] 
    public string? BuilderId { get; set; }
    
    [BsonIgnoreIfNull] 
    public List<Document>? Documents { get; set; }
    
    [BsonIgnoreIfNull] 
    public List<Document>? DesignerDocuments { get; set; }
    
    [BsonIgnoreIfNull] 
    public Form? DesignerForm { get; set; }
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime CreatedDate { get; set; }
}