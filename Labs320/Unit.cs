using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Labs320
{
    internal class Unit
    {
        public Unit(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Unit(string name, int age, int driverCard)
        {
            Name = name;
            Age = age;
            DriverCard = driverCard;
        }

        [BsonIgnoreIfDefault] 
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public int Age { get; set; }
        [BsonIgnoreIfDefault]
        public int DriverCard { get; set; }
    }
}
