namespace CharacterCreator.Core;

public struct CharacterStats
{
    public double Strength { get; set; }
    public double Constitution { get; set; }
    public double Intelligence { get; set; }
    public double Dexterity { get; set; }
    
    public double HealthPoint { get; set; }
    public double ManaPoint { get; set; }
    public double PhysAttack { get; set; }
    public double PhysDefense { get; set; }
    public double MagicalAttack { get; set; }

    public CharacterStats(double strength, double constitution, double intelligence, double dexterity, double healthPoint, double manaPoint, double physAttack, double physDefense, double magicalAttack)
    {
        Strength = strength;
        Constitution = constitution;
        Intelligence = intelligence;
        Dexterity = dexterity;
        HealthPoint = healthPoint;
        ManaPoint = manaPoint;
        PhysAttack = physAttack;
        PhysDefense = physDefense;
        MagicalAttack = magicalAttack;
    }
}