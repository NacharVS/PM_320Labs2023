namespace CharacterEditor.Core.Characteristics;

public class CharacteristicChangeEventArgs : EventArgs
{
    /// <summary>
    /// Difference between previous and new values
    /// </summary>
    public int Difference { get; }

    public CharacteristicChangeEventArgs(int difference)
    {
        Difference = difference;
    }
}