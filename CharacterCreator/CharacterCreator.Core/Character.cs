using CharacterCreator.Core.Characteristics;
namespace CharacterCreator.Core;

public class Character
{
    public Stats Stats { get; private protected set; }
    public int SkillPoints { get; private protected set; } = 5;
    

    private double _strength;
    private double _dexterity;
    private double _constitution;
    private double _intelligence;

    public double Strength
    {
        get => _strength;
        set
        {
            if (Stats.Strength.MaxValue >= value &&
                Stats.Strength.MinValue <= value && CanChangeStat(value, _strength))
            {
                OnStrengthChangeEvent?.Invoke(value - _strength);
                _strength = value;
                SkillPoints -= 1;
            }
        }
    }

    public double Dexterity
    {
        get => _dexterity;
        set
        {
            if (Stats.Dexterity.MaxValue >= value &&
                Stats.Dexterity.MinValue <= value  && CanChangeStat(value, _dexterity))
            {
                OnDexterityChangeEvent?.Invoke(value - _dexterity);
                _dexterity = value;
                SkillPoints -= 1;
            }
        }
    }

    public double Constitution
    {
        get => _constitution;
        set
        {
            if (Stats.Constitution.MaxValue >= value &&
                Stats.Constitution.MinValue <= value && CanChangeStat(value, _constitution))
            {
                OnConstitutionChangeEvent?.Invoke(value - _constitution);
                _constitution = value;
                SkillPoints -= 1;
            }
        }
    }

    public double Intelligence
    {
        get => _intelligence;
        set
        {
            if (Stats.Intelligence.MaxValue >= value &&
                Stats.Intelligence.MinValue <= value && CanChangeStat(value, _intelligence))
            {
                OnIntelligenceChangeEvent?.Invoke(value - _intelligence);
                _intelligence = value;
                SkillPoints -= 1;
            }
        }
    }

    public bool CanChangeStat(double newValue, double oldValue)
    {
        if (newValue > oldValue)
        {
            if (newValue - oldValue > SkillPoints)
                return false;
        }

        return true;
    }

    public double HealthPoint { get; protected set; } 
    public double PhysAttack { get; protected set; }
    public double PhysDefense { get; protected set; }
    public double Mana { get; protected set; }
    public double MagicalAttack { get; protected set; }

    public void Initialize()
    {
        _intelligence = Stats.Intelligence.MinValue;
        _strength = Stats.Strength.MinValue;
        _constitution = Stats.Constitution.MinValue;
        _dexterity = Stats.Dexterity.MinValue;
    }

    public delegate void OnCharacteristicChangeDelegate(double value);

    public event OnCharacteristicChangeDelegate OnStrengthChangeEvent;
    public event OnCharacteristicChangeDelegate OnDexterityChangeEvent;
    public event OnCharacteristicChangeDelegate OnConstitutionChangeEvent;
    public event OnCharacteristicChangeDelegate OnIntelligenceChangeEvent;
}