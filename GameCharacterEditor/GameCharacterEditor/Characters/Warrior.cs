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
            get { return _strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    HP += (value - _strength) * 2;
                    Attack += (value - _strength) * 5;
                    _strength = value;
                }
            }
        }
        public new int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value >= minDexterity && value <= maxDexterity)
                {
                    Attack += (value - _dexterity) * 1;
                    PDef += (value - _dexterity) * 1;
                    _dexterity = value;
                }
            }
        }
        public new int Constitution
        {
            get { return _constitution; }
            set
            {
                if (value >= minConstitution && value <= maxConstitution)
                {
                    HP += (value - _constitution) * 10;
                    PDef += (value - _constitution) * 12;
                    _constitution = value;
                }
            }
        }
        public new int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIntelligence)
                {
                    MP += (value - _intelligence) * 1;
                    MPAttack += (value - _intelligence) * 1;
                    _intelligence = value;
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
