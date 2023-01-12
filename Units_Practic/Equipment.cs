using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units_Practic.Items;

namespace Units_Practic
{
    [BsonDiscriminator ("Equipment")]
    public class Equipment
    {
        public Helmet? helmet;
        public ChestArmor? armor;
        public Weapon? weapon;

        public Equipment() { }
    }
}
