using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Character
    {
        public string Name { get; set; }
        // Сила
        public int minStrength;
        public int maxStrength;
        public int _strength; 
        public int Strength
        {
            get { return _strength; }
            set 
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    _strength = value;
                }
            }
        }

        // Ловкость
        public int minDexterity;
        public int maxDexterity;
        public int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set 
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    _dexterity = value;
                }
            }
        }

        // Телосложение
        public int minConstitution;
        public int maxConstitution;
        public int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set 
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    _constitution = value;
                }
            }
        }

        // Интеллект 
        public int minIntelligence;
        public int maxIntelligence;
        public int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set 
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    _intelligence = value;
                }
            }
        }

        public int HP { get; set; } // Здоровье
        public double MP { get; set; } // Мана
        public double PDef { get; set; } // Физическая защита (Physical defention)
        public int Attack { get; set; } // Атака (урон)
        public int MPAttack { get; set; } // Магическая атака
    }
}
