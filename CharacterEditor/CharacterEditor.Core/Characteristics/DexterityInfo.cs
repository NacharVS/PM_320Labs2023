namespace CharacterEditor.Core.Characteristics;

public class DexterityInfo : CharacteristicInfoBase
{
    public double AttackChange { get; }
    public double PhysicalDefenceChange { get; }

    public DexterityInfo(int minValue, int maxValue, double attackChange, double physicalDefenceChange) : base(minValue, maxValue)
    {
        AttackChange = attackChange;
        PhysicalDefenceChange = physicalDefenceChange;
    }

    public DexterityInfo(CharacteristicRange range, double attackChange, double physicalDefenceChange) : base(range)
    {
        AttackChange = attackChange;
        PhysicalDefenceChange = physicalDefenceChange;
    }
}