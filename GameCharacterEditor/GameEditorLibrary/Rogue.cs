﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorLibrary
{
    public class Rogue : Unit
    {
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;

        public int attackDamage;
        public int manaAttack;
        public double phDefention;
        public double HP;
        public double MP;

        public Rogue() 
        {
            maxIintelligence = 70;
            minIntelligence = 15;
            minStrength = 15;
            maxStrength = 55;
            minDexterity = 30;
            maxDexterity = 250;
            minConstitution = 20;
            maxConstitution = 80;
            strength = minStrength;
            dexterity = minDexterity;
            constitution = minConstitution;
            intelligence = minIntelligence;
        }
    }
}