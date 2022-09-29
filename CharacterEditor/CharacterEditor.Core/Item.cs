namespace CharacterEditor.Core;

public class Item
{
    public string Name { get; set; } = String.Empty;

    public override string ToString()
    {
        return Name;
    }
}