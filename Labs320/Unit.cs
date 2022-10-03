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
            inventory = new List<Item>();
        }

        public Unit(string name, int age, int driverCard)
        {
            Name = name;
            Age = age;
            DriverCard = driverCard;
            inventory = new List<Item>();
        }

        public Unit()
        {
        }

        [BsonIgnoreIfDefault] 
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public int Age { get; set; }
        [BsonIgnoreIfDefault]
        public int DriverCard { get; set; }

        [BsonIgnoreIfNull]
        public string WarTicket { get; set; }

        [BsonIgnoreIfNull]
        public List<Item> inventory;

        public void AddToInventory(Item item)
        {
            inventory.Add(item);
        }
    }
}
