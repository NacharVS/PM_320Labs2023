using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Wizard : Character
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
                    Attack += (value - minStrength) * 3;
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
                    HP += (value - minConstitution) * 3;
                    PDef += (value - minConstitution) * 1;
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
                    MP += (value - minIntelligence) * 2;
                    MPAttack += (value - minIntelligence) * 5;
                    minIntelligence = value;
                }
            }
        }
        public Wizard(string name)
        {
            this.Name = name;
            minStrength = 10;
            maxStrength = 45;
            minDexterity = 20;
            maxDexterity = 70;
            minConstitution = 15;
            maxConstitution = 60;
            minIntelligence = 35;
            maxIntelligence = 250;
        }
    }
}
