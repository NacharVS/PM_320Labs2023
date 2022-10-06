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
        public int Level
        {
            get { return _level; }
            set
            {
                if (value > 0)
                {
                    _level = value;
                    points += 5;
                }    
                else
                {
                    _level = value;
                }
            }
        }
        public int CurrentExpa
        {
            get { return _expa; }
            set
            {
                if (value - _nexpa ==  1000 + 1000 * _level)
                {
                    _nexpa = value;
                    Level++;
                }
                _expa = value;
            }
        }
        public int points;
        private int _expa;
        private int _nexpa;
        public List<Item> inventory;
        public List<Skill> skills;
        private int _level;
        public Helmet helmet;
        public Chestplate chestplate;
        public Boots boots;

        public Unit() 
        { 
            inventory =new List<Item>();
            skills =new List<Skill>();
            Level = 0;
            CurrentExpa = 0;
            points = 0;
            _expa = 0;
            _nexpa = 0;
        }

        public void AddToInventory(Item item)
        {
            inventory.Add(item);
        }

        public void AddToSkills(Skill skill)
        {
            skills.Add(skill);
        }
    }
}