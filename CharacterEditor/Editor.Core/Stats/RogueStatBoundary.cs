namespace Editor.Core.Stats;

public class RogueStatBoundary : BaseStatBoundary
{
    public RogueStatBoundary()
    {
        MinStrength = 15;
        MaxStrength = 55;
        MinDexterity = 30;
        MaxDexterity = 250;
        MinConstitution = 20;
        MaxConstitution = 80;
        MinIntelligence = 15;
        MaxIntelligence = 70;
    }
}