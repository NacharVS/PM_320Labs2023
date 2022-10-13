using CharacterCreator.Core.Characteristics;

namespace CharacterCreator.Core;

public class Equipment : BaseItem
{
    // Required Stats
    public int RequiredLevel { get; set; }
    public double RequiredDexterity { get; set; }
    public double RequiredStrength { get; set; }
    public double RequiredIntelligence { get; set; }
    public double RequiredConstitution { get; set; }
    
    // Stats, that give this item
    public double HealthPoint { get; set; }
    public double ManaPoint { get; set; }
    public double PhysAttack { get; set; }
    public double PhysDefense { get; set; }
    public double MagicalAttack { get; set; }
    
    public double Strength { get; set; }
    public double Dexterity { get; set; }
    public double Intelligence { get; set; }
    public double Constitution { get; set; }
    public bool IsEquipped { get; set; }

    public Equipment(string name, int requiredLevel, double requiredDexterity, double requiredStrength, 
        double requiredIntelligence, double requiredConstitution) : base(name)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        RequiredDexterity = requiredDexterity;
        RequiredStrength = requiredStrength;
        RequiredIntelligence = requiredIntelligence;
        RequiredConstitution = requiredConstitution;
    }

    public Equipment(string name, int requiredLevel, double requiredDexterity, double requiredStrength, 
        double requiredIntelligence, double requiredConstitution, double healthPoint, double manaPoint, 
        double physAttack, double physDefense, double magicalAttack,
        double strength, double dexterity, double intelligence, double constitution, EquipmentType type,
        bool isEquipped = false) : base(name)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        RequiredDexterity = requiredDexterity;
        RequiredStrength = requiredStrength;
        RequiredIntelligence = requiredIntelligence;
        RequiredConstitution = requiredConstitution;
        HealthPoint = healthPoint;
        ManaPoint = manaPoint;
        PhysAttack = physAttack;
        PhysDefense = physDefense;
        MagicalAttack = magicalAttack;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Constitution = constitution;
        Type = type;
        IsEquipped = isEquipped;
    }

    public string GetTotalInfo()
    {
        return $"Name: {Name}\nType: {Type}\n\nRequired:\n Str: {RequiredStrength} Dex: {RequiredDexterity}\n " +
               $"Int: {RequiredIntelligence} Const: {RequiredConstitution}\n Lvl: {RequiredLevel}\n\nGive:\n Str: {Strength} Dex: {Dexterity}\n " +
               $"Int: {Intelligence} Const: {Constitution} \n\n HP: {HealthPoint} MP: {ManaPoint}\n " +
               $"Phys attack: {PhysAttack} Mana attack: {MagicalAttack}\n Phys defense: {PhysDefense}";
    }
    
    public override string ToString()
    {
        string equippedText = IsEquipped ? "Equipped" : "Unequipped";
        return $"{Name} | {Type} | {equippedText}";
    }
}   