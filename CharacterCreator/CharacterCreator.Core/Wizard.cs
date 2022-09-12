using CharacterCreator.Core.Characteristics;

namespace CharacterCreator.Core;

public class Wizard : Character
{
    private const double STRENGTH_ATTACK_CHANGE = 3;
    private const double STRENGTH_HP_CHANGE = 1;
    private CharacteristicBoundary _strength = new CharacteristicBoundary(10, 45);
    
    private const double DEXTERITY_PHYS_DEFENSE_CHANGE = .5;
    private CharacteristicBoundary _dexterity = new CharacteristicBoundary(20, 70);
    
    private const double CONSTITUTION_HP_CHANGE = 3;
    private const double CONSTITUTION_PHYS_DEFENSE_CHANGE = 1;
    private CharacteristicBoundary _constitution = new CharacteristicBoundary(15, 60);
    
    private const double INTELLIGENCE_MANA_CHANGE = 2;
    private const double INTELLIGENCE_MAGICAL_ATTACK_CHANGE = 5;
    private CharacteristicBoundary _intelligence = new CharacteristicBoundary(35, 250);

    public Wizard()
    {
        Stats = new Stats(_strength, _dexterity, _intelligence, _constitution);
        Initialize();

        HealthPoint = STRENGTH_HP_CHANGE * _strength.MinValue + CONSTITUTION_HP_CHANGE * _constitution.MinValue;
        PhysAttack = STRENGTH_ATTACK_CHANGE * _strength.MinValue;
        PhysDefense = DEXTERITY_PHYS_DEFENSE_CHANGE * _dexterity.MinValue +
                      CONSTITUTION_PHYS_DEFENSE_CHANGE * _constitution.MinValue;
        Mana = INTELLIGENCE_MANA_CHANGE * _intelligence.MinValue;
        MagicalAttack = INTELLIGENCE_MAGICAL_ATTACK_CHANGE * _intelligence.MinValue;
        
        OnDexterityChangeEvent += DexterityChange;
        OnStrengthChangeEvent += StrengthChange;
        OnConstitutionChangeEvent += ConstitutionChange;
        OnIntelligenceChangeEvent += IntelligenceChange;
    }

    public void StrengthChange(double value)
    {
        PhysAttack += STRENGTH_ATTACK_CHANGE * value;   
        HealthPoint += STRENGTH_HP_CHANGE * value;
    }

    public void DexterityChange(double value)
    {
        PhysDefense += DEXTERITY_PHYS_DEFENSE_CHANGE * value;
    }

    public void ConstitutionChange(double value)
    {
        HealthPoint += CONSTITUTION_HP_CHANGE * value;
        PhysDefense += CONSTITUTION_PHYS_DEFENSE_CHANGE * value;
    }

    public void IntelligenceChange(double value)
    {
        Mana += INTELLIGENCE_MANA_CHANGE * value;
        MagicalAttack += INTELLIGENCE_MAGICAL_ATTACK_CHANGE * value;
    }
}