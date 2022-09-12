using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Rogue : Character
    {
        public string Name { get; set; }
        public new int Strength
        {
            get { return minStrength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    HP += (value - minStrength) * 1;
                    Attack += (value - minStrength) * 2;
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
                    Attack += (value - minDexterity) * 4;
                    PDef += (value - minDexterity) * 1.5;
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
                    HP += (value - minConstitution) * 6;
                    minConstitution = value;
                }
            }
        }
        public new int MinIntelligence
        {
            get { return minIntelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    MP += (value - minIntelligence) * 1.5;
                    MPAttack += (value - minIntelligence) * 2;
                    minIntelligence = value;
                }
            }
        }
        public Rogue(string name)
        {
            this.Name = name;
            minStrength = 15;
            maxStrength = 55;
            minDexterity = 30;
            maxDexterity = 250;
            minConstitution = 20;
            maxConstitution = 80;
            minIntelligence = 15;
            maxIntelligence = 70;
        }
    }
}
