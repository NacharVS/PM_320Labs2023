namespace CharacterEditor.Core.Characteristics;

public abstract class CharacteristicInfoBase
{
    public CharacteristicRange Range;

    public CharacteristicInfoBase(int minValue, int maxValue)
    {
        Range = new CharacteristicRange(minValue, maxValue);
    }

    public CharacteristicInfoBase(CharacteristicRange range)
    {
        Range = range;
    }
}