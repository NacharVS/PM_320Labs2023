namespace CharacterEditor.Core.Characteristics;

public class ConstitutionInfo : CharacteristicInfoBase
{
    public double HpChange { get; }
    public double PhysicalDefenceChange { get; }
    
    public ConstitutionInfo(int minValue, int maxValue, double hpChange, double physicalDefenceChange) : base(minValue, maxValue)
    {
        HpChange = hpChange;
        PhysicalDefenceChange = physicalDefenceChange;
    }
    
    public ConstitutionInfo(CharacteristicRange range, double hpChange, double physicalDefenceChange) : base(range)
    {
        HpChange = hpChange;
        PhysicalDefenceChange = physicalDefenceChange;
    }
}