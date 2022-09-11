namespace CharacterCreator.Core.Characteristics;

public class Stats
{
    public CharacteristicBoundary Strength { get; private set; }
    public CharacteristicBoundary Dexterity { get; private set; }
    public CharacteristicBoundary Intelligence { get; private set; }
    public CharacteristicBoundary Constitution { get; private set; }

    public Stats(CharacteristicBoundary strength, CharacteristicBoundary dexterity, 
        CharacteristicBoundary intelligence, CharacteristicBoundary constitution)
    {
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Constitution = constitution;
    }
}