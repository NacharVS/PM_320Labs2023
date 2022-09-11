
using CharacterCreator.Core.Characteristics;

namespace CharacterCreator.Core;

public class Rogue : Character
{
    private const double STRENGTH_ATTACK_CHANGE = 2;
    private const double STRENGTH_HP_CHANGE = 1;
    private CharacteristicBoundary _strength = new CharacteristicBoundary(15, 55);
    
    private const double DEXTERITY_ATTACK_CHANGE = 4;
    private const double DEXTERITY_PHYS_DEFENSE_CHANGE = 1.5;
    private CharacteristicBoundary _dexterity = new CharacteristicBoundary(30, 250);
    
    private const double CONSTITUTION_HP_CHANGE = 6;
    private CharacteristicBoundary _constitution = new CharacteristicBoundary(20, 80);
    
    private const double INTELLIGENCE_MANA_CHANGE = 1.5;
    private const double INTELLIGENCE_MAGICAL_ATTACK_CHANGE = 1;
    private CharacteristicBoundary _intelligence = new CharacteristicBoundary(15, 70);

    public Rogue()
    {
        Stats = new Stats(_strength, _dexterity, _intelligence, _constitution);
        Initialize();

        HealthPoint = STRENGTH_HP_CHANGE * _strength.MinValue + CONSTITUTION_HP_CHANGE * _strength.MinValue;
        PhysAttack = STRENGTH_ATTACK_CHANGE * _strength.MinValue + DEXTERITY_ATTACK_CHANGE * _dexterity.MinValue;
        PhysDefense = DEXTERITY_PHYS_DEFENSE_CHANGE * _dexterity.MinValue;
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
        PhysAttack += DEXTERITY_ATTACK_CHANGE * value;
        PhysDefense += DEXTERITY_PHYS_DEFENSE_CHANGE * value;
    }

    public void ConstitutionChange(double value)
    {
        HealthPoint += CONSTITUTION_HP_CHANGE * value;
    }

    public void IntelligenceChange(double value)
    {
        Mana += INTELLIGENCE_MANA_CHANGE * value;
        MagicalAttack += INTELLIGENCE_MAGICAL_ATTACK_CHANGE * value;
    }
}