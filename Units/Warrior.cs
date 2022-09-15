using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    class Warrior : Unit
    {
        public Warrior()
        {
            minStrength = 30;
            maxStrength = 250;
            minDexterity = 15;
            maxDexterity = 70;
            minConstitution = 20;
            maxConstitution = 100;
            minIntelligence = 10;
            maxIntelligence = 50;

            StrengthChangedEvent += delegate
            {
                healthPoint = Strength * 2 + Constitution * 10;
                damage = Strength * 5 + Dexterity;
            };

            DexterityChangedEvent += delegate
            {
                defense = Dexterity + Constitution * 2;
                damage = Strength * 5 + Dexterity;
            };

            ConstitutionChangedEvent += delegate
            {
                healthPoint = Strength * 2 + Constitution * 10;
                defense = Dexterity + Constitution * 2;
            };

            IntelligenceChangedEvent += delegate
            {
                damage = Intelligence;
                manaPoint = Intelligence;
            };

            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}
