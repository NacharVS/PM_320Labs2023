namespace Editor.Core.Stats;

public struct CharacterStats
{
    public int Strength { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    
    public double Health { get; set; }
    public double Mana { get; set; }
    public double PhysicalDamage { get; set; }
    public double PhysicalDefense { get; set; }
    public double MagicDamage { get; set; }
    public double MagicDefense { get; set; }
    public double Level { get; set; }

    public CharacterStats(int strength, int constitution, int dexterity, int intelligence, double health, double mana, 
        double physicalDamage, double physicalDefense, double magicDamage, double magicDefense, int level)
    {
        Strength = strength;
        Constitution = constitution;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Health = health;
        Mana = mana;
        PhysicalDamage = physicalDamage;
        PhysicalDefense = physicalDefense;
        MagicDamage = magicDamage;
        MagicDefense = magicDefense;
        Level = level;
    }
}