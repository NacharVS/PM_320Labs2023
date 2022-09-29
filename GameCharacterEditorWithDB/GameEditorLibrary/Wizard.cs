using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Wizard : Unit
    {
        public override int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    attackDamage += (value - _strength) * 3;
                    HP += (value - _strength);
                    _strength = value;
                }
                else
                {
                    throw new Exception();
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
                    phDefention += (value - _dexterity) * 0.5;
                    _dexterity = value;
                }
                else
                {
                    throw new Exception();
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
                    HP += (value - _constitution) * 3;
                    phDefention += (value - _constitution);
                    _constitution = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public override int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value >= minIntelligence && value <= maxIintelligence)
                {
                    MP += (value - _intelligence) * 2;
                    manaAttack += (value - _intelligence) * 5;
                    _intelligence = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Wizard()
        {
            typeOfUnit = "Wizard";
            maxIintelligence = 250;
            minIntelligence = 35;
            minStrength = 10;
            maxStrength = 45;
            minDexterity = 20;
            maxDexterity = 70;
            minConstitution = 15;
            maxConstitution = 60;
            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}