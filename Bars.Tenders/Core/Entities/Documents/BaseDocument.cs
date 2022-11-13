using Core.Enums;
using MongoDB.Bson;

namespace Core.Entities.Documents;

/// <summary>
/// Базовое представление документа
/// </summary>
public class BaseDocument : BaseEntity
{
    public string Name { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsRequired { get; set; }
    public ObjectId OwnerId { get; set; }
    public ObjectId FileId { get; set; }
    public ObjectId ProjectId { get; set; }
}