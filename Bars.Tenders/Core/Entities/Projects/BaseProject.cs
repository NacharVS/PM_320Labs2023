using Core.Enums;
using MongoDB.Bson;

namespace Core.Entities.Projects;

/// <summary>
/// Базовое представление проекта
/// </summary>
public class BaseProject : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public ObjectId CustomerId { get; set; }
    public ObjectId ArchitectId { get; set; }
    public ObjectId BuilderId { get; set; }
    public IndustryType IndustryType { get; set; }
}