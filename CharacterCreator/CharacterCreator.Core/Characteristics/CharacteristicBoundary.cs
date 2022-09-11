namespace CharacterCreator.Core.Characteristics;

public class CharacteristicBoundary
{
    public int MinValue { get; set; }
    public int MaxValue { get; set; }

    public CharacteristicBoundary(int minValue, int maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
}