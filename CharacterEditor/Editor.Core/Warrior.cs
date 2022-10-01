using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Core.Abilities;
using Editor.Core.Enums;
using Editor.Core.Helpers;
using Editor.Core.Inventory;

namespace Editor.Core;

public class Warrior : Character
{
    public Warrior(int availableSkillPoints, int experience, IEnumerable<Ability?>? abilities, string? name, List<InventoryItem> inventory) 
        : base(new WarriorStatBoundary(), availableSkillPoints, experience, abilities, name, inventory)
    {
        Initialize();
    }

    public Warrior(int availableSkillPoints, int experience, int strength, int dexterity, 
        int constitution, int intelligence, IEnumerable<Ability?>? abilities, string? name, List<InventoryItem> inventory)
        : base(new WarriorStatBoundary(), availableSkillPoints, experience, abilities, name, inventory)
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

        if (!ignoreStatsBoundary)
        {
            Strength = StatsBoundary.MinStrength;
            Dexterity = StatsBoundary.MinDexterity;
            Constitution = StatsBoundary.MinConstitution;
            Intelligence = StatsBoundary.MinIntelligence;
        }
    }
}