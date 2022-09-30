namespace CharacterCreator.Core;

public class Item
{
    public string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}