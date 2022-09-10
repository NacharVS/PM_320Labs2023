﻿namespace CharacterEditor.Core.Characteristics;

public class CharacteristicRange
{
    public int MinValue { get; init; }
    public int MaxValue { get; init; }

    public CharacteristicRange(int minValue, int maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
}