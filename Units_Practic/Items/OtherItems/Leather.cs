using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.OtherItems
{
    [BsonDiscriminator("Leather")]
    public class Leather : Item
    {
        public Leather()
        {
            name = "Leather";
        }
    }
}
