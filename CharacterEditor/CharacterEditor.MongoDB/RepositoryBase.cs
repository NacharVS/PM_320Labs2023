using CharacterEditor.Core.Misc;

namespace CharacterEditor.MongoDB;

public class RepositoryBase
{
    protected static Item ConvertItem(ItemDb itemDb)
    {
        return new Item
        {
            Name = itemDb.Name ?? String.Empty, AttackChange = itemDb.AttackChange,
            HealthChange = itemDb.HealthChange,
            ManaChange = itemDb.ManaChange,
            MagicalAttackChange = itemDb.MagicalAttackChange,
            PhysicalResistanceChange = itemDb.PhysicalResistanceChange,
            ClassName = itemDb.ClassName, Type = itemDb.Type,
            MinimumLevel = itemDb.MinimumLevel,
            ConstitutionChange = itemDb.ConstitutionChange,
            DexterityChange = itemDb.DexterityChange,
            IntelligenceChange = itemDb.IntelligenceChange,
            StrengthChange = itemDb.StrengthChange
        };
    }

    protected static ItemDb ConvertItem(Item item)
    {
        return new ItemDb
        {
            Name = item.Name, AttackChange = item.AttackChange,
            HealthChange = item.HealthChange, ManaChange = item.ManaChange,
            MagicalAttackChange = item.MagicalAttackChange,
            PhysicalResistanceChange = item.PhysicalResistanceChange,
            Type = item.Type, ClassName = item.ClassName,
            MinimumLevel = item.MinimumLevel, ConstitutionChange = item.ConstitutionChange,
            DexterityChange = item.DexterityChange, IntelligenceChange = item.IntelligenceChange,
            StrengthChange = item.StrengthChange
        };
    }
}