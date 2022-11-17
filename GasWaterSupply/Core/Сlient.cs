using Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Сlient : IPrimaryData
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Department;
        public string? Name;
        public string? LastName;
        public string? Patronymic;

        public Сlient()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}