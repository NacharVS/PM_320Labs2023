namespace Editor.Core.Inventory;

public class Equipment : InventoryItem
{
    public EquipmentSlot Slot { get; set; }
    public bool IsEquipped { get; set; }

    // Required stats
    public int RequiredStrength { get; set; }
    public int RequiredDexterity { get; set; }
    public int RequiredConstitution { get; set; }
    public int RequiredIntelligence { get; set; }
    public int EquipmentLevel { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public double HealthPoints { get; set; }
    public double ManaPoints { get; set; }
    public double PhysicalDamage { get; set; }
    public double MagicDamage { get; set; }
    public double PhysicalDefense { get; set; }
    public double MagicDefense { get; set; }

    public Equipment(EquipmentSlot slot, string? name, int requiredStrength, int requiredDexterity, int requiredConstitution, int requiredIntelligence, 
        int equipmentLevel, double healthPoints, double manaPoints, double physicalDamage, double magicDamage, 
        double physicalDefense, double magicDefense, int strength, int constitution, int dexterity, int intelligence) : base(name)
    {
        Slot = slot;
        Name = name;
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        RequiredStrength = requiredStrength;
        RequiredDexterity = requiredDexterity;
        RequiredConstitution = requiredConstitution;
        RequiredIntelligence = requiredIntelligence;
        EquipmentLevel = equipmentLevel;
        HealthPoints = healthPoints;
        ManaPoints = manaPoints;
        PhysicalDamage = physicalDamage;
        MagicDamage = magicDamage;
        PhysicalDefense = physicalDefense;
        MagicDefense = magicDefense;
    }

    public override string GetDescription()
    {
        return $"Slot: {Slot}\nName: {Name}\nRequired Strength: {RequiredStrength}\nRequiredDexterity: {RequiredDexterity}\nRequiredConstitution: {RequiredConstitution}\n" +
               $"RequiredIntelligence: {RequiredIntelligence}\nHealthPoints: {HealthPoints}\nManaPoints: {ManaPoints}\n" +
               $"Strength: {Strength}\nDexterity:{Dexterity}\nConstitution:{Constitution}\nIntelligence: {Intelligence}\nPhysical Damage: {PhysicalDamage}\n" +
               $"Magic Damage: {MagicDamage}\nPhysical Defense: {PhysicalDefense}\nMagic Defense: {MagicDefense}";
    }
}