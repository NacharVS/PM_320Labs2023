using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Enums;

namespace Editor.Core
{
    public class Rogue : Character
    {
        public Rogue(int availableSkillPoints) 
            : base(new RogueStatBoundary(), availableSkillPoints)
        {
            Initialize();
        }

        public void Initialize()
        {
            OnStrengthChange += delegate (Character _, int difference)
            {
                HealthPoints += difference;
                PhysicalDamage += difference * 2;
            };

            OnDexterityChange += delegate (Character _, int difference)
            {
                PhysicalDamage += difference * 4;
                PhysicalDefense += difference * 1.5;
            };

            OnConstitutionChange += delegate (Character _, int difference)
            {
                HealthPoints += difference * 6;
            };

            OnIntelligenceChange += delegate (Character _, int difference)
            {
                MagicDamage += difference * 2;
                MagicDefense += difference * 1.5;
            };

            StatsBoundary = new RogueStatBoundary();

            Strength = StatsBoundary.MinStrength;
            Dexterity = StatsBoundary.MinDexterity;
            Constitution = StatsBoundary.MinConstitution;
            Intelligence = StatsBoundary.MinIntelligence;

            //HealthPoints = Strength + Constitution * 6;
            //PhysicalDamage = Strength * 2 + Dexterity * 4;
            //PhysicalDefense = Dexterity * 1.5;
            //MagicDamage = 2 * Intelligence;
            //MagicDefense = 1.5 * Intelligence;
        }
    }
}
