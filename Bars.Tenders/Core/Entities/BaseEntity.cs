using Core.Entities.Interfaces;
using MongoDB.Bson;

namespace Core.Entities;

/// <summary>
/// Базовая сущность системы
/// </summary>
public class BaseEntity : IHaveId
{
    public ObjectId _id { get; set; }
}