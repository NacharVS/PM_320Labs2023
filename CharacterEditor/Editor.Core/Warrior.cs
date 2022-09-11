using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Enums;
using Editor.Core.Helpers;

namespace Editor.Core;

public class Warrior : Character
{
    public Warrior(int availableSkillPoints) 
        : base(new WarriorStatBoundary(), availableSkillPoints)
    {
        Initialize();
    }

    public void Initialize()
    {
        OnStrengthChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            HealthPoints += args.Difference * 2;
            PhysicalDamage += args.Difference * 5;
        };

        OnDexterityChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            PhysicalDamage += args.Difference;
            PhysicalDefense += args.Difference;
        };

        OnConstitutionChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            HealthPoints += args.Difference * 10;
            PhysicalDefense += args.Difference * 2;
        };

        OnIntelligenceChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            MagicDamage += args.Difference;
            ManaPoints += args.Difference;
        };

        Strength = StatsBoundary.MinStrength;
        Dexterity = StatsBoundary.MinDexterity;
        Constitution = StatsBoundary.MinConstitution;
        Intelligence = StatsBoundary.MinIntelligence;
    }
}