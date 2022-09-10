using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor.Characters
{
    class Character
    {
        public string Name { get; set; }  // Имя
        public int MinStrength { get; set; } // Сила
        public int MaxStrength { get; set; }
        public int MinDexterity { get; set; } // Ловкость 
        public int MaxDexterity { get; set; }
        public int MinConstitution { get; set; } // Телосложение
        public int MaxConstitution { get; set; }
        public int MinIntelligence { get; set; } // Интеллект 
        public int MaxIntelligence { get; set; }
        public int MP { get; set; } // Мана
        public int HP { get; set; } // Здоровье
        public int PDef { get; set; } // Физическая защита (Physical defention)
        public int Attack { get; set; } // Атака (урон)

        public Character (string name, int minStrength, int maxStrength, 
            int minDexterity, int maxDexterity,int minConstitution, int maxConstitution, 
            int minIntelligence, int maxIntelligence, int mP, int hP,  int pDef, int attack)
        {
            this.Name = name;
            this.MinStrength = minStrength;
            this.MaxStrength = maxStrength;
            this.MinDexterity = minDexterity;
            this.MaxDexterity = maxDexterity;
            this.MinConstitution = minConstitution;
            this.MaxConstitution = maxConstitution;
            this.MinIntelligence = minIntelligence;
            this.MaxIntelligence = maxIntelligence;
            this.MP = mP;
            this.HP = hP;
            this.PDef = pDef;
            this.Attack = attack;
        }   


    }
}
