using System.Text.RegularExpressions;
using CharacterCreator.Core.Characteristics;
namespace CharacterCreator.Core;

public class Character
{
    public Stats Stats { get; private protected set; }
    public int SkillPoints { get; set; } = 1005;


    private double _strength;
    private double _dexterity;
    private double _constitution;
    private double _intelligence;
    
    public string? Id { get; set; }
    public string Name { get; set; }
    public LevelInfo Level { get; set; }

    private const int InventoryCapacity = 3;
    private List<Item> _inventory = new();

    private  List<Ability> abilities = new();
    

    public List<Item> Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }

    public List<Ability> Abilities
    {
        get => abilities;
        set => abilities = value;
    }

    public void AddItemToInventory(Item item)
    {
        if (InventoryCapacity > _inventory.Count)
            _inventory.Add(item);
    }

    public void RemoveItemFromInventory(Item item)
    {
        _inventory.Remove(item);
    }
    

    public double Strength
    {
        get => _strength;
        set
        {
            if (Stats.Strength.MaxValue >= value &&
                Stats.Strength.MinValue <= value && CanChangeStat(value, _strength))
            {
                OnStrengthChangeEvent?.Invoke(value - _strength);
                SkillPoints -= (int) (value - _strength);
                _strength = value;
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
                SkillPoints -= (int) (value - _dexterity);
                _dexterity = value;
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
                SkillPoints -= (int) (value - _constitution);
                _constitution = value;
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
                SkillPoints -= (int) (value - _intelligence);
                _intelligence = value;
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

    public bool AddAbility(Ability ability)
    {
        if (ability.RequiredLevel > Level.CurrentLvl)
            return false;
        
        abilities.Add(ability);
        OnAbilityAddEvent?.Invoke(ability);
        return true;
    }

    public double HealthPoint { get; protected set; } 
    public double PhysAttack { get; protected set; }
    public double PhysDefense { get; protected set; }
    public double Mana { get; protected set; }
    public double MagicalAttack { get; protected set; }

    public void Initialize(int exp = 0)
    {
        Level = new LevelInfo();
        Level.CurrentExperience = exp;
        Level.LevelUpEvent += OnLevelUp;
        OnAbilityAddEvent += (ability) =>
        {
            HealthPoint += ability.HealthChangeValue;
            Mana += ability.ManaChangeValue;
            MagicalAttack += ability.ManaAttackChangeValue;
            PhysAttack += ability.PhysAttackChangeValue;
            PhysDefense += ability.PhysDefenseChangeValue;
        };
        
        _intelligence = Stats.Intelligence.MinValue;
        _strength = Stats.Strength.MinValue;
        _constitution = Stats.Constitution.MinValue;
        _dexterity = Stats.Dexterity.MinValue;
    }

    public void OnLevelUp()
    {
        SkillPoints += 5;
    }

    public delegate void OnCharacteristicChangeDelegate(double value);

    public delegate void OnAbilityAddDelegate(Ability ability);

    public event OnCharacteristicChangeDelegate OnStrengthChangeEvent;
    public event OnAbilityAddDelegate OnAbilityAddEvent;
    public event OnCharacteristicChangeDelegate OnDexterityChangeEvent;
    public event OnCharacteristicChangeDelegate OnConstitutionChangeEvent;
    public event OnCharacteristicChangeDelegate OnIntelligenceChangeEvent;
}