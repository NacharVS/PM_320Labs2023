﻿using System;
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
                if (value >= minStrength && value <= maxStrength)
                {
                    attackDamage += (value - _strength) * 5;
                    HP += (value - _strength) * 2;
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
                    attackDamage += (value - _dexterity);
                    phDefention += (value - _dexterity);
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
                    HP += (value - _constitution) * 10;
                    phDefention += (value - _constitution) * 2;
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
                    MP += (value - _intelligence);
                    manaAttack += (value - _intelligence);
                    _intelligence = value;
                }
                else
                {
                    throw new Exception();
                }

            }
        }

        public Warrior()
        {
            typeOfUnit = "Warrior";
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