using CharacterEditor.Core.Classes;

namespace CharacterEditor.Core.Misc;

public static class Defaults
{
    public static readonly Ability[] DefaultAbilities = {
        new()
        {
            Name = "Berserker", AttackChange = 10, HealthChange = 50,
            ManaChange = 0, MagicalAttackChange = 0,
            PhysicalResistanceChange = 20
        },
        new()
        {
            Name = "Magician", AttackChange = 0, HealthChange = 0,
            ManaChange = 50, MagicalAttackChange = 10,
            PhysicalResistanceChange = 0
        },
        new()
        {
            Name = "Protected", AttackChange = 0, HealthChange = 50,
            ManaChange = 0, MagicalAttackChange = 0,
            PhysicalResistanceChange = 50
        }, new()
        {
            Name = "Crazy", AttackChange = 60, HealthChange = 0,
            ManaChange = 0, MagicalAttackChange = 0,
            PhysicalResistanceChange = 0
        },
        new()
        {
            Name = "Adrenalined", AttackChange = 20, HealthChange = 20,
            ManaChange = 0, MagicalAttackChange = 0,
            PhysicalResistanceChange = 20
        },
        new()
        {
            Name = "Firearmed", AttackChange = 0, HealthChange = 0,
            ManaChange = 50, MagicalAttackChange = 50,
            PhysicalResistanceChange = 0
        },
        new()
        {
            Name = "Loaded", AttackChange = 40, HealthChange = 40,
            ManaChange = 0, MagicalAttackChange = 40,
            PhysicalResistanceChange = 40
        },
        new()
        {
            Name = "Universal", AttackChange = 5, HealthChange = 5,
            ManaChange = 5, MagicalAttackChange = 5,
            PhysicalResistanceChange = 5
        },
        new()
        {
            Name = "Hardcore", AttackChange = -5, HealthChange = -5,
            ManaChange = -5, MagicalAttackChange = -5,
            PhysicalResistanceChange = -5
        },
        new()
        {
            Name = "Empty", AttackChange = 0, HealthChange = 0,
            ManaChange = 0, MagicalAttackChange = 0,
            PhysicalResistanceChange = 0
        },
    };

    public static readonly Item[] DefaultItems =
    {
        new()
        {
            Name = "Strong helmet", Type = ItemType.Helmet, AttackChange = 0,
            ClassName = nameof(Warrior), MinimumLevel = 3, HealthChange = 50,
            ManaChange = 0, MagicalAttackChange = 0, PhysicalResistanceChange = 15,
            StrengthChange = 10, ConstitutionChange = 5, DexterityChange = 0, IntelligenceChange = 0
        },
        new()
        {
            Name = "Cuirass", Type = ItemType.Armor, AttackChange = 0,
            ClassName = nameof(Warrior), MinimumLevel = 5, HealthChange = 150,
            ManaChange = 0, MagicalAttackChange = 0, PhysicalResistanceChange = 35,
            StrengthChange = 15, ConstitutionChange = 20, DexterityChange = -5, IntelligenceChange = 0
        },
        new()
        {
            Name = "Sword", Type = ItemType.Weapon, AttackChange = 100,
            ClassName = nameof(Warrior), MinimumLevel = 5, HealthChange = 0,
            ManaChange = 0, MagicalAttackChange = 0, PhysicalResistanceChange = 0,
            StrengthChange = 10, ConstitutionChange = 0, DexterityChange = 0, IntelligenceChange = 0
        },
        new()
        {
            Name = "Funny hat", Type = ItemType.Helmet, AttackChange = 0,
            ClassName = nameof(Wizard), MinimumLevel = 2, HealthChange = 20,
            ManaChange = 100, MagicalAttackChange = 50, PhysicalResistanceChange = 0,
            StrengthChange = 0, ConstitutionChange = 0, DexterityChange = 0, IntelligenceChange = 10
        },
        new()
        {
            Name = "Robe of Magi", Type = ItemType.Armor, AttackChange = 0,
            ClassName = nameof(Wizard), MinimumLevel = 5, HealthChange = 50,
            ManaChange = 150, MagicalAttackChange = 30, PhysicalResistanceChange = 5,
            StrengthChange = 0, ConstitutionChange = 5, DexterityChange = 0, IntelligenceChange = 20
        },
        new()
        {
            Name = "Magic stick", Type = ItemType.Weapon, AttackChange = 5,
            ClassName = nameof(Wizard), MinimumLevel = 3, HealthChange = 50,
            ManaChange = 50, MagicalAttackChange = 150, PhysicalResistanceChange = 0,
            StrengthChange = 0, ConstitutionChange = 5, DexterityChange = 5, IntelligenceChange = 30
        },
        new()
        {
            Name = "Hood", Type = ItemType.Helmet, AttackChange = 50,
            ClassName = nameof(Rogue), MinimumLevel = 3, HealthChange = 50,
            ManaChange = 0, MagicalAttackChange = 0, PhysicalResistanceChange = 5,
            StrengthChange = 0, ConstitutionChange = 2, DexterityChange = 15, IntelligenceChange = 0
        },
        new()
        {
            Name = "Jacket", Type = ItemType.Armor, AttackChange = 70,
            ClassName = nameof(Rogue), MinimumLevel = 5, HealthChange = 150,
            ManaChange = 0, MagicalAttackChange = 0, PhysicalResistanceChange = 15,
            StrengthChange = 5, ConstitutionChange = 5, DexterityChange = 20, IntelligenceChange = 0
        },
        new()
        {
            Name = "Backstab knife", Type = ItemType.Weapon, AttackChange = 150,
            ClassName = nameof(Rogue), MinimumLevel = 3, HealthChange = 0,
            ManaChange = 0, MagicalAttackChange = 0, PhysicalResistanceChange = -15,
            StrengthChange = 5, ConstitutionChange = -5, DexterityChange = 30, IntelligenceChange = 0
        },
    };
}