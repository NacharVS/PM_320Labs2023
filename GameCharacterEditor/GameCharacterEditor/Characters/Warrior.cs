using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Warrior : Character
    {
        public string Name { get; set; }
        public new int Strength
        {
            get { return minStrength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    HP += (value - minStrength) * 2;
                    Attack += (value - minStrength) * 5;
                    minStrength = value;
                }
            }
        }
        public new int Dexterity
        {
            get { return minDexterity; }
            set
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    Attack += (value - minDexterity) * 1;
                    PDef += (value - minDexterity) * 1;
                    minDexterity = value;
                }
            }
        }
        public new int Constitution
        {
            get { return minConstitution; }
            set
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    HP += (value - minConstitution) * 10;
                    PDef += (value - minConstitution) * 12;
                    minConstitution = value;
                }
            }
        }
        public new int Intelligence
        {
            get { return minIntelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    MP += (value - minIntelligence) * 1;
                    MPAttack += (value - minIntelligence) * 1;
                    minIntelligence = value;
                }
            }
        }
        public Warrior(string name)
        {
            this.Name = name;
            minStrength = 30;
            maxStrength = 250;
            minDexterity = 15;
            maxDexterity = 70;
            minConstitution = 20;
            maxConstitution = 100;
            minIntelligence = 10;
            maxIntelligence = 50;
        }
    }
}
