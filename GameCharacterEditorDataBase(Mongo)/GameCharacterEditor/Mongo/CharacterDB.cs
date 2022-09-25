using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class CharacterDB 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonIgnoreIfNull]
        public string? Name { get; set; }

        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public int Intelligence { get; set; }

        [BsonIgnoreIfDefault]
        public decimal HP { get; set; }
        [BsonIgnoreIfDefault]
        public decimal MP { get; set; }
        [BsonIgnoreIfDefault]
        public decimal PDef { get; set; }
        [BsonIgnoreIfDefault]
        public decimal Attack { get; set; }
        [BsonIgnoreIfDefault]
        public decimal MPAttack { get; set; }

        public CharacterDB (string id, string name, int strength, int dexterity, int constitution, int intelligence, decimal hP, decimal mP, decimal pDef, decimal attack, decimal mPAttack)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            HP = hP;
            MP = mP;
            PDef = pDef;
            Attack = attack;
            MPAttack = mPAttack;
        }
    }
}
