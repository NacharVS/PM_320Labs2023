namespace CharacterEditor.Core.Misc;

public class Item : ICanChangeStats, ICanChangeCharacteristics
{
    public string? Name { get; set; } = string.Empty;
    public string? ClassName { get; set; } = string.Empty;
    public ItemType Type { get; set; }
    public string? TypeName => Enum.GetName(typeof(ItemType), Type);
    public int MinimumLevel { get; set; }
    public int HealthChange { get; init; }
    public int ManaChange { get; init; }
    public int PhysicalResistanceChange { get; init; }
    public int AttackChange { get; init; }
    public int MagicalAttackChange { get; init; }
    public int StrengthChange { get; init; }
    public int DexterityChange { get; init; }
    public int ConstitutionChange { get; init; }
    public int IntelligenceChange { get; init; }

    public override string ToString()
    {
        return Name;
    }
}