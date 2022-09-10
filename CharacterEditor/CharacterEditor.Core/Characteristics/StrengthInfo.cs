namespace CharacterEditor.Core.Characteristics;

public class StrengthInfo : CharacteristicInfoBase
{
    public double AttackChange { get; }
    public double HpChange { get; }
    
    public StrengthInfo(int minValue, int maxValue, double attackChange, double hpChange) : base(minValue, maxValue)
    {
        AttackChange = attackChange;
        HpChange = hpChange;
    }
    
    public StrengthInfo(CharacteristicRange range, double attackChange, double hpChange) : base(range)
    {
        AttackChange = attackChange;
        HpChange = hpChange;
    }
}