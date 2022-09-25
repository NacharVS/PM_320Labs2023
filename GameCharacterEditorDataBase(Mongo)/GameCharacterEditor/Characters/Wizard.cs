using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterEditor
{
    class Wizard : Character
    {
        public override int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    HP += (value - _strength) * 1;
                    Attack += (value - _strength) * 3;
                    _strength = value;
                }
            }
        }
        public override int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    Attack += (value - _dexterity) * 4;
                    PDef += (value - _dexterity) * (int)1.5;
                    _dexterity = value;
                }
            }
        }
        public override int Constitution
        {
            get { return minConstitution; }
            set
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    HP += (value - _constitution) * 3;
                    PDef += (value - _constitution) * 1;
                    _constitution = value;
                }
            }
        }
        public override int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    MP += (value - _intelligence) * 2;
                    MPAttack += (value - _intelligence) * 5;
                    _intelligence = value;
                }
            }
        }
        public Wizard(string name)
        {
            Name = "Wizard";
            minStrength = 10;
            maxStrength = 45;
            minDexterity = 20;
            maxDexterity = 70;
            minConstitution = 15;
            maxConstitution = 60;
            minIntelligence = 35;
            maxIntelligence = 250;
            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}
