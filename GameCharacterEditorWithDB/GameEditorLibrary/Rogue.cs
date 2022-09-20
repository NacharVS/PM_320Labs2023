﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Rogue : Unit
    {
        public override int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= minStrength && value <= maxStrength)
                {
                    attackDamage += (value - _strength) * 2;
                    HP += (value - _strength);
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
                    attackDamage += (value - _dexterity) * 4;
                    phDefention += (value - _dexterity) * 1.5;
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
                if (value >= minIntelligence && value <= maxIintelligence)
                {
                    MP += (value - _intelligence) * 1.5;
                    manaAttack += (value - _intelligence) * 2;
                    _intelligence = value;
                }

            }
        }
        public Rogue() 
        {
            typeOfUnit = "Rogue";
            maxIintelligence = 70;
            minIntelligence = 15;
            minStrength = 15;
            maxStrength = 55;
            minDexterity = 30;
            maxDexterity = 250;
            minConstitution = 20;
            maxConstitution = 80;
            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}