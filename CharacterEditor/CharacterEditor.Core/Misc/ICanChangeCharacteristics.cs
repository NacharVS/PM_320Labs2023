namespace CharacterEditor.Core.Misc;

public interface ICanChangeCharacteristics
{
    public int StrengthChange { get; init; }
    public int DexterityChange { get; init; }
    public int ConstitutionChange { get; init; }
    public int IntelligenceChange { get; init; }
}