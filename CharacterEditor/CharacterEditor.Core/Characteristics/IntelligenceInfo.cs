namespace CharacterEditor.Core.Characteristics;

public class IntelligenceInfo : CharacteristicInfoBase
{
    public double ManaChange { get; }
    public double MagicalAttackChange { get; }
    
    public IntelligenceInfo(int minValue, int maxValue, double manaChange, double magicalAttackChange) : base(minValue, maxValue)
    {
        ManaChange = manaChange;
        MagicalAttackChange = magicalAttackChange;
    }

    public IntelligenceInfo(CharacteristicRange range, double manaChange,
        double magicalAttackChange) : base(range)
    {
        ManaChange = manaChange;
        MagicalAttackChange = magicalAttackChange;
    }
}