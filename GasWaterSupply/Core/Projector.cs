using Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Projector : IRequisites, IPrimaryData
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? INN { get; set; }
        public string? KPP { get; set; }
        public string? OGRN { get; set; }
        public string? Adress { get; set; }
        public string? NameOfCompany { get; set; }
        public string? ManagerLastName;
        public string? ManagerPatronymic;
        public string? ManagerName;
        public string? EngineerLastName;
        public string? EngineerPatronymic;
        public string? EngineerName;

        public Projector()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
