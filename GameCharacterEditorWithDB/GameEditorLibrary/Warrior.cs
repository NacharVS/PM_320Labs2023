using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Warrior : Unit
    {
        public override int Strength
        {
            get { return _strength; }
            set
            {
                attackDamage += (value - _strength) * 5;
                HP += (value - _strength) * 2;
                _strength = value;
            }
        }

        public override int Dexterity
        {
            get { return _dexterity; }
            set
            {
                attackDamage += (value - _dexterity);
                phDefention += (value - _dexterity);
                _dexterity = value;
            }
        }
        public override int Constitution
        {
            get { return _constitution; }
            set
            {
                HP += (value - _constitution) * 10;
                phDefention += (value - _constitution) * 2;
                _constitution = value;
            }
        }
        public override int Intelligence
        {
            get { return _intelligence; }
            set
            {
                MP += (value - _intelligence);
                manaAttack += (value - _intelligence);
                _intelligence = value;
            }
        }

        public Warrior()
        {
            maxIintelligence = 50;
            minIntelligence = 10;
            minStrength = 30;
            maxStrength = 250;
            minDexterity = 15;
            maxDexterity = 70;
            minConstitution = 20;
            maxConstitution = 100;
            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}