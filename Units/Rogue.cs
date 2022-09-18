using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units
{
    class Rogue : Unit
    {
        public Rogue()
        {
            maxStrength = 55;
            minStrength = 15;
            minDexterity = 30;
            maxDexterity = 250;
            minConstitution = 20;
            maxConstitution = 80;
            minIntelligence = 15;
            maxIntelligence = 70;

            StrengthChangedEvent += delegate
            {
                healthPoint = Strength + Constitution * 6;
                damage = Strength * 2 + Dexterity * 4;
            };

            DexterityChangedEvent += delegate
            {
                defense = Dexterity * 1.5;
                damage = Strength * 2 + Dexterity * 4;
            };

            ConstitutionChangedEvent += delegate
            {
                healthPoint = Strength + Constitution * 6;
            };

            IntelligenceChangedEvent += delegate
            {
                damage = Intelligence * 2;
                manaPoint = Intelligence * 1.5;
            };

            Strength = minStrength;
            Dexterity = minDexterity;
            Constitution = minConstitution;
            Intelligence = minIntelligence;
        }
    }
}
