using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Enums;

namespace Editor.Core
{
    public class Warrior : Character
    {
        public Warrior(int availableSkillPoints) 
            : base(new WarriorStatBoundary(), availableSkillPoints)
        {
            Initialize();
        }

        public void Initialize()
        {
            OnStrengthChange += delegate (Character _, int difference)
            {
                HealthPoints += difference * 2;
                PhysicalDamage += difference * 5;
            };

            OnDexterityChange += delegate (Character _, int difference)
            {
                PhysicalDamage += difference;
                PhysicalDefense += difference;
            };

            OnConstitutionChange += delegate (Character _, int difference)
            {
                HealthPoints += difference * 10;
                PhysicalDefense += Constitution * 2;
            };

            OnIntelligenceChange += delegate (Character _, int difference)
            {
                MagicDamage += difference;
                MagicDefense += difference;
            };

            Strength = StatsBoundary.MinStrength;
            Dexterity = StatsBoundary.MinDexterity;
            Constitution = StatsBoundary.MinConstitution;
            Intelligence = StatsBoundary.MinIntelligence;

            //HealthPoints = Strength * 2 + Constitution * 10;
            //PhysicalDamage = Strength * 5 + Dexterity;
            //PhysicalDefense = Dexterity + Constitution * 2;
            //MagicDamage = Intelligence;
            //MagicDefense = Intelligence;
        }
    }
}
