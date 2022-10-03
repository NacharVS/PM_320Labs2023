using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GameCharacterEditor
{
    class Character
    {
        public ObjectId Id;
        public string Type { get; set; }
        public string Name { get; set; }

        // Сила
        public int minStrength;
        public int maxStrength;
        public int _strength;
        public virtual int Strength
        {
            get { return _strength; }
            set 
            {
                if (value < minStrength || value > maxStrength)
                    throw new Exception();

                _strength = value;
            }
        }

        // Ловкость
        public int minDexterity;
        public int maxDexterity;
        public int _dexterity;
        public virtual int Dexterity
        {
            get { return _dexterity; }
            set 
            {
                if (value < minDexterity || value > maxDexterity)
                    throw new Exception();

                _dexterity = value;
            }
        }

        // Телосложение
        public int minConstitution;
        public int maxConstitution;
        public int _constitution;
        public virtual int Constitution
        {
            get { return _constitution; }
            set 
            {
                if (value < minConstitution || value > maxConstitution)
                    throw new Exception();

                _constitution = value;
            }
        }

        // Интеллект 
        public int minIntelligence;
        public int maxIntelligence;
        public int _intelligence;
        public virtual int Intelligence
        {
            get { return _intelligence; }
            set 
            {
                if (value < minIntelligence || value > maxIntelligence)
                    throw new Exception();

                _intelligence = value;
            }
        }

        public decimal HP { get; set; } // Здоровье
        public decimal MP { get; set; } // Мана
        public decimal PDef { get; set; } // Физическая защита (Physical defention)
        public decimal Attack { get; set; } // Атака (урон)
        public decimal MPAttack { get; set; } // Магическая атака

        public int Points { get; set; }

        [BsonIgnoreIfNull]
        public List<Equipment> equipment;
        public void AddToEquipment(Equipment item)
        {
            equipment.Add(item);
        }

        public List<string> equipmentList = new List<string>();
        public void AddToEquipmentName(string item)
        {
            equipmentList.Add(item);
        }
        [BsonIgnoreIfNull]
        public List<Skill> skill;
        public void AddToSkill(Skill item)
        {
            skill.Add(item);
        }
        public List<string> skillList = new List<string>();
        public void AddToSkillName(string item)
        {
            skillList.Add(item);
        }
        public Character()
        {
            equipment = new List<Equipment>();
            skill = new List<Skill>();
        }

        public int minLvl { get; set; } = 1;
        public int Lvl { get; set; } = 1;
        public int minXPLvl { get; set; } 
        public int XPLvl { get; set; }
        public int XP { get; set; }
    }
}
