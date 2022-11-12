using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data
{
    public class User
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }


        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
