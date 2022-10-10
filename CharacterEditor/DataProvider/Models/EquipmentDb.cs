using Editor.Core.Inventory;

namespace DataProvider.Models;

public class EquipmentDb : BaseModel
{
    public EquipmentSlot Slot { get; set; }
    public bool IsEquipped { get; set; }
    
    // Required stats
    public int RequiredStrength { get; set; }
    public int RequiredDexterity { get; set; }
    public int RequiredConstitution { get; set; }
    public int RequiredIntelligence { get; set; }
    public int EquipmentLevel { get; set; }
    
    public double HealthPoints { get; set; }
    public double ManaPoints { get; set; }
    public double PhysicalDamage { get; set; }
    public double MagicDamage { get; set; }
    public double PhysicalDefense { get; set; }
    public double MagicDefense { get; set; }

    public EquipmentDb(string id, string? name, EquipmentSlot slot, bool isEquipped, int requiredStrength, int requiredDexterity, 
        int requiredConstitution, int requiredIntelligence, int equipmentLevel, double healthPoints, 
        double manaPoints, double physicalDamage, double magicDamage, double physicalDefense, double magicDefense)
    {
        Id = id;
        Name = name;
        Slot = slot;
        IsEquipped = isEquipped;
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

    public EquipmentDb(string id, Equipment equipment)
    {
        Id = id;
        Name = equipment.Name;
        Slot = equipment.Slot;
        IsEquipped = equipment.IsEquipped;
        RequiredStrength = equipment.RequiredStrength;
        RequiredDexterity = equipment.RequiredDexterity;
        RequiredConstitution = equipment.RequiredConstitution;
        RequiredIntelligence = equipment.RequiredIntelligence;
        EquipmentLevel = equipment.EquipmentLevel;
        HealthPoints = equipment.HealthPoints;
        ManaPoints = equipment.ManaPoints;
        PhysicalDamage = equipment.PhysicalDamage;
        MagicDamage = equipment.MagicDamage;
        PhysicalDefense = equipment.PhysicalDefense;
        MagicDefense = equipment.MagicDefense;
    }
}