using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Enums;
using Editor.Core.Helpers;

namespace Editor.Core;

public class Wizard : Character
{
    public Wizard(int availableSkillPoints, int experience) 
        : base(new WizardStatBoundary(), availableSkillPoints, experience)
    {
        Initialize();
    }
    
    public Wizard(int availableSkillPoints, int experience, int strength, int dexterity, int constitution, int intelligence)
        : base(new WizardStatBoundary(), availableSkillPoints, experience)
    {
        Initialize(true);
        
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
    }

    public void Initialize(bool ignoreStatsBoundary=false)
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

            PhysicalDamage += args.Difference;
            PhysicalDefense += args.Difference * 0.5;
        };

        OnConstitutionChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            HealthPoints += args.Difference * 3;
            PhysicalDefense += args.Difference;
        };

        OnIntelligenceChange += delegate (Character _, StatChangeArgs args)
        {
            if (args.Handled)
            {
                return;
            }

            MagicDamage += args.Difference * 5;
            ManaPoints += args.Difference * 2;
        };

        if (!ignoreStatsBoundary)
        {
            Strength = StatsBoundary.MinStrength;
            Dexterity = StatsBoundary.MinDexterity;
            Constitution = StatsBoundary.MinConstitution;
            Intelligence = StatsBoundary.MinIntelligence;
        }
    }
}