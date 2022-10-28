using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.OtherItems
{
    [BsonDiscriminator("Bread")]
    public class Bread : Item
    {
        public Bread()
        {
            name = "Bread";
        }
    }
}
