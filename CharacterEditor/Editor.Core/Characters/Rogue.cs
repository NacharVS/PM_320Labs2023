using Editor.Core.Abilities;
using Editor.Core.Helpers;
using Editor.Core.Inventory;
using Editor.Core.Stats;

namespace Editor.Core.Characters;

public class Rogue : Character
{
    public Rogue(int availableSkillPoints, int experience, IEnumerable<Ability?>? abilities, string? name, List<Equipment?> inventory) 
        : base(new RogueStatBoundary(), availableSkillPoints, experience, abilities, name, inventory)
    {
        Initialize();
    }
    
    public Rogue(int availableSkillPoints, int experience, int strength, int dexterity, 
        int constitution, int intelligence, IEnumerable<Ability?>? abilities, string? name, List<Equipment?> inventory)
        : base(new RogueStatBoundary(), availableSkillPoints, experience, abilities, name, inventory)
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

        if (!ignoreStatsBoundary)
        {
            Strength = StatsBoundary.MinStrength;
            Dexterity = StatsBoundary.MinDexterity;
            Constitution = StatsBoundary.MinConstitution;
            Intelligence = StatsBoundary.MinIntelligence;
        }
    }
}