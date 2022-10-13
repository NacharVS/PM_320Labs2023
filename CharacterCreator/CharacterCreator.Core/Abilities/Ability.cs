namespace CharacterCreator.Core;

public class Ability
{
    public string Name { get; set; }
    public int RequiredLevel { get; init; }
    
    public int HealthChangeValue { get; set; }
    public int ManaChangeValue { get; set; }
    public int ManaAttackChangeValue { get; set; }
    public int PhysAttackChangeValue { get; set; }
    public int PhysDefenseChangeValue { get; set; }


    public Ability(string name, int requiredLevel, int healthChangeValue, int manaChangeValue, int manaAttackChangeValue, int physAttackChangeValue, int physDefenseChangeValue)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        HealthChangeValue = healthChangeValue;
        ManaChangeValue = manaChangeValue;
        ManaAttackChangeValue = manaAttackChangeValue;
        PhysAttackChangeValue = physAttackChangeValue;
        PhysDefenseChangeValue = physDefenseChangeValue;
    }

    public Ability(string name, int requiredLevel)
    {
        Name = name;
        RequiredLevel = requiredLevel;
    }
}