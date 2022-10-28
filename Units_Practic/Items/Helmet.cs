﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic.Items
{
    [BsonDiscriminator("Helmet")]
    public abstract class Helmet : Item, IEquipment
    {
        public bool equip { get; set; }
        
        public Helmet() 
        { 
            type = TypeItem.Helmet;
        }
    }
}
