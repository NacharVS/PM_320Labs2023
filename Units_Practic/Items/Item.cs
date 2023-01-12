using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items
{
    public enum TypeItem
    {
        Weapon,
        Helmet,
        ChestArmor
    }

    [BsonDiscriminator("Item")]
    public abstract class Item
    {
        public ObjectId _id = ObjectId.GenerateNewId();
        public string name { get; set; }
        public TypeItem? type { get; set; }

        public Item(string name)
        {
            this.name = name;
        }

        public Item() { }

        public override string ToString()
        {
            return name;
        }
    }
}
