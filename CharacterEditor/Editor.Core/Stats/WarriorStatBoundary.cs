namespace Editor.Core.Stats;

public class WarriorStatBoundary : BaseStatBoundary
{
    public WarriorStatBoundary()
    {
        MinStrength = 30;
        MaxStrength = 250;
        MinDexterity = 15;
        MaxDexterity = 70;
        MinConstitution = 20;
        MaxConstitution = 100;
        MinIntelligence = 10;
        MaxIntelligence = 50;
    }
}