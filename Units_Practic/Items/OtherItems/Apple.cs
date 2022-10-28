using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items.OtherItems
{
    [BsonDiscriminator("Apple")]
    public class Apple : Item
    {
        public Apple()
        {
            name = "Apple";
        }
    }
}
