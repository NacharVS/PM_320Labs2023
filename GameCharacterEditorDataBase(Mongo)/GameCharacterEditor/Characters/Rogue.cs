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
        public override int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    HP += (value - _strength) * 1;
                    Attack += (value - _strength) * 2;
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
            get { return _constitution; }
            set
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    HP += (value - _constitution) * 6;
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
                    MP += (value - _intelligence) * (int)1.5;
                    MPAttack += (value - _intelligence) * 2;
                    _intelligence = value;
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
            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}
