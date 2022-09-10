using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Enums;

namespace Editor.Core
{
    public class Wizard : Character
    {
        public Wizard(int availableSkillPoints) 
            : base(new WizardStatBoundary(), availableSkillPoints)
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
                PhysicalDamage += difference;
                PhysicalDefense += difference * 0.5;
            };

            OnConstitutionChange += delegate (Character _, int difference)
            {
                HealthPoints += difference * 3;
                PhysicalDefense += Constitution;
            };

            OnIntelligenceChange += delegate (Character _, int difference)
            {
                MagicDamage += difference * 5;
                MagicDefense += difference * 2;
            };

            Strength = StatsBoundary.MinStrength;
            Dexterity = StatsBoundary.MinDexterity;
            Constitution = StatsBoundary.MinConstitution;
            Intelligence = StatsBoundary.MinIntelligence;

            //HealthPoints = Strength + Constitution * 3;
            //PhysicalDamage = Strength * 2;
            //PhysicalDefense = Dexterity * 0.5 + Constitution;
            //MagicDamage = 5 * Intelligence;
            //MagicDefense = 2 * Intelligence;
        }
    }
}
