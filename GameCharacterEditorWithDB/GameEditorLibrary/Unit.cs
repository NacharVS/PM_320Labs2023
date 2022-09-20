using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameEditorLibrary
{
    public class Unit
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [BsonIgnoreIfDefault]
        public string typeOfUnit;
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        public int minStrength;
        public int maxStrength;
        protected int _strength;
        public virtual int Strength { get; set; }
        public int minDexterity;
        public int maxDexterity;
        protected int _dexterity;
        public virtual int Dexterity { get; set; }
        public int minConstitution;
        public int maxConstitution;
        protected int _constitution;
        public virtual int Constitution { get; set; }
        public int minIntelligence;
        public int maxIintelligence;
        protected int _intelligence;
        public virtual int Intelligence { get; set; }
        public int attackDamage;
        public int manaAttack;
        public double phDefention;
        public double HP;
        public double MP;

        public Unit() { }
    }
}