namespace CharacterEditor.Core.Misc;

public interface ICanChangeStats
{
    public int HealthChange { get; init; }
    public int ManaChange { get; init; }
    public int PhysicalResistanceChange { get; init; }
    public int AttackChange { get; init; }
    public int MagicalAttackChange { get; init; }
}