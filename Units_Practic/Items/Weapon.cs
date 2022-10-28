using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items
{
    [BsonDiscriminator("Weapon")]
    public abstract class Weapon : Item, IEquipment
    {
        public bool equip { get; set; }

        public Weapon()
        {
            type = TypeItem.Weapon;
        }
    }
}
