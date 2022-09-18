using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    class Wizard : Unit
    {
        public Wizard()
        {
            minStrength = 10;
            maxStrength = 45;
            minDexterity = 20;
            maxDexterity = 70;
            minConstitution = 15;
            maxConstitution = 60;
            minIntelligence = 35;
            maxIntelligence = 250;

            StrengthChangedEvent += delegate
            {
                healthPoint = Strength + Constitution * 3;
                damage = Strength * 3;
            };

            DexterityChangedEvent += delegate
            {
                defense = Dexterity * 0.5 + Constitution;
            };

            ConstitutionChangedEvent += delegate
            {
                healthPoint = Strength + Constitution * 3;
                defense = Dexterity * 0.5 + Constitution;
            };

            IntelligenceChangedEvent += delegate
            {
                damage = Intelligence * 5;
                manaPoint = Intelligence * 2;
            };

            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}
