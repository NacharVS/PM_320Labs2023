namespace CharacterEditor.Core.Characteristics;

/// <summary>
///  Base class for characteristic's infos
/// </summary>
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