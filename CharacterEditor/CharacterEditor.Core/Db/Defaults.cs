using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core.Db;

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
}