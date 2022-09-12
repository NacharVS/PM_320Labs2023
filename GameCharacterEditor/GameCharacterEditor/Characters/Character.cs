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
        public int Strength
        {
            get { return minStrength; }
            set 
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    minStrength = value;
                }
            }
        }

        // Ловкость
        public int minDexterity;
        public int maxDexterity;
        public int Dexterity
        {
            get { return minDexterity; }
            set 
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    minDexterity = value;
                }
            }
        }

        // Телосложение
        public int minConstitution;
        public int maxConstitution;
        public int Constitution
        {
            get { return minConstitution; }
            set 
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    minConstitution = value;
                }
            }
        }

        // Интеллект 
        public int minIntelligence;
        public int maxIntelligence;
        public int Intelligence
        {
            get { return minIntelligence; }
            set 
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    minIntelligence = value;
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
