namespace CharacterEditor.Core.Characteristics;

public class CharacteristicChangeEventArgs : EventArgs
{
    public int Difference { get; }

    public CharacteristicChangeEventArgs(int difference)
    {
        Difference = difference;
    }
}