using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Enums;
using Editor.Core.Helpers;

namespace Editor.Core;

public class Rogue : Character
{
    public Rogue(int availableSkillPoints) 
        : base(new RogueStatBoundary(), availableSkillPoints)
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

            HealthPoints += args.Difference;
            PhysicalDamage += args.Difference * 2;
        };

        OnDexterityChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            PhysicalDamage += args.Difference * 4;
            PhysicalDefense += args.Difference * 1.5;
        };

        OnConstitutionChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            HealthPoints += args.Difference * 6;
        };

        OnIntelligenceChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            MagicDamage += args.Difference * 2;
            ManaPoints += args.Difference * 1.5;
        };

        StatsBoundary = new RogueStatBoundary();

        Strength = StatsBoundary.MinStrength;
        Dexterity = StatsBoundary.MinDexterity;
        Constitution = StatsBoundary.MinConstitution;
        Intelligence = StatsBoundary.MinIntelligence;
    }
}