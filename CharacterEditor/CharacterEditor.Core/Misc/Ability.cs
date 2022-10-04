namespace CharacterEditor.Core.Misc;

public class Ability : ICanChangeStats
{
    public string? Name { get; set; }
    public int HealthChange { get; init; }
    public int ManaChange { get; init; }
    public int PhysicalResistanceChange { get; init; }
    public int AttackChange { get; init; }
    public int MagicalAttackChange { get; init; }
}