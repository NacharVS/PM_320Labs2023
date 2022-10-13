using CharacterCreator.Core.Characteristics;

namespace CharacterCreator.Core;

/// <summary>
/// Base character clas
/// </summary>
public class Character
{
    public BoundaryStats BoundaryStats { get; private protected set; }
    public int SkillPoints { get; set; } = 1005;


    private double _strength;
    private double _dexterity;
    private double _constitution;
    private double _intelligence;


    public double HealthPoint { get; protected set; }
    public double PhysAttack { get; protected set; }
    public double PhysDefense { get; protected set; }
    public double Mana { get; protected set; }
    public double MagicalAttack { get; protected set; }

    public string? Id { get; set; }
    public string Name { get; set; }
    public LevelInfo Level { get; set; }

    private const int InventoryCapacity = 5;
    private List<BaseItem> _inventory = new();
 
    private List<Ability> abilities = new();

    public List<BaseItem> Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }

    public List<Ability> Abilities
    {
        get => abilities;
        set => abilities = value;
    }

    /// <summary>
    /// Add new items in inventory
    /// </summary>
    /// <param name="baseItem">Item that add</param>
    public void AddItemToInventory(Equipment baseItem)
    {
        if (InventoryCapacity > _inventory.Count)
            _inventory.Add(baseItem);
    }

    public void RemoveItemFromInventory(Equipment baseItem)
    {
        _inventory.Remove(baseItem);
    }

    public double Strength
    {
        get => _strength;
        set
        {
            if (BoundaryStats.Strength.MaxValue >= value &&
                BoundaryStats.Strength.MinValue <= value && CanChangeStat(value, _strength))
            {
                OnStrengthChangeEvent?.Invoke(value - _strength);
                SkillPoints -= (int)(value - _strength);
                _strength = value;
            }
        }
    }

    public double Dexterity
    {
        get => _dexterity;
        set
        {
            if (BoundaryStats.Dexterity.MaxValue >= value &&
                BoundaryStats.Dexterity.MinValue <= value && CanChangeStat(value, _dexterity))
            {
                OnDexterityChangeEvent?.Invoke(value - _dexterity);
                SkillPoints -= (int)(value - _dexterity);
                _dexterity = value;
            }
        }
    }

    public double Constitution
    {
        get => _constitution;
        set
        {
            if (BoundaryStats.Constitution.MaxValue >= value &&
                BoundaryStats.Constitution.MinValue <= value && CanChangeStat(value, _constitution))
            {
                OnConstitutionChangeEvent?.Invoke(value - _constitution);
                SkillPoints -= (int)(value - _constitution);
                _constitution = value;
            }
        }
    }

    public double Intelligence
    {
        get => _intelligence;
        set
        {
            if (BoundaryStats.Intelligence.MaxValue >= value &&
                BoundaryStats.Intelligence.MinValue <= value && CanChangeStat(value, _intelligence))
            {
                OnIntelligenceChangeEvent?.Invoke(value - _intelligence);
                SkillPoints -= (int)(value - _intelligence);
                _intelligence = value;
            }
        }
    }

    public CharacterStats TotalStats => GetTotalStats();

    /// <summary>
    /// Sum all stats from character, abilities and items
    /// </summary>
    /// <returns>Return resulted stats</returns>
    private CharacterStats GetTotalStats()
    {
        return new CharacterStats(
            _strength + _inventory.Where(x => ((x as Equipment)).IsEquipped).Sum(x => 
                (x as Equipment)?.Strength) ?? 0,
            _constitution + _inventory.Where(x => ((x as Equipment)).IsEquipped)
                .Sum(x => (x as Equipment)?.Constitution) ?? 0,
            _intelligence + _inventory.Where(x => ((x as Equipment)).IsEquipped)
                .Sum(x => (x as Equipment)?.Intelligence) ?? 0,
            _dexterity + _inventory.Where(x => (x as Equipment).IsEquipped).Sum(x => 
                (x as Equipment)?.Dexterity) ?? 0,
            HealthPoint + abilities.Sum(x => x.HealthChangeValue) +
            _inventory.Where(x => (x as Equipment).IsEquipped).Sum(x => (x as Equipment)?.HealthPoint) ?? 0,
            Mana + abilities.Sum(x => x.ManaChangeValue) +
            _inventory.Where(x => ((x as Equipment)).IsEquipped).Sum(x => (x as Equipment)?.ManaPoint) ?? 0,
            PhysAttack + abilities.Sum(x => x.PhysAttackChangeValue) +
            _inventory.Where(x => ((x as Equipment)).IsEquipped).Sum(x => (x as Equipment)?.PhysAttack) ?? 0,
            PhysDefense + abilities.Sum(x => x.PhysDefenseChangeValue) +
            _inventory.Where(x => ((x as Equipment)).IsEquipped).Sum(x => (x as Equipment)?.PhysDefense) ?? 0,
            MagicalAttack + abilities.Sum(x => x.ManaAttackChangeValue) +
            _inventory.Where(x => ((x as Equipment)).IsEquipped).Sum(x => (x as Equipment)?.MagicalAttack) ?? 0
        );
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

    /// <summary>
    /// Add ability, if can do this
    /// </summary>
    /// <param name="ability">Ability to add</param>
    /// <returns>True - add | False - cant add</returns>
    public bool AddAbility(Ability ability)
    {
        if (ability.RequiredLevel > Level.CurrentLvl)
            return false;

        abilities.Add(ability);
        return true;
    }

    public bool CanEquip(EquipmentType type)
    {
        var equippedItems = _inventory.Where(x => (x as Equipment).IsEquipped && x.Type == type).ToArray();
        return equippedItems.Length == 0;
    }

    /// <summary>
    /// Check item and character stats for convergence
    /// </summary>
    /// <param name="eq">Item that need to check</param>
    /// <returns></returns>
    public bool CheckItemConvergence(Equipment eq)
    {
        return eq.RequiredConstitution <= TotalStats.Constitution && eq.RequiredDexterity <= TotalStats.Dexterity &&
               eq.RequiredIntelligence <= TotalStats.Intelligence && eq.RequiredStrength <= TotalStats.Strength;
    }


    /// <summary>
    /// Initialize character 
    /// </summary>
    /// <param name="exp">Experience count, default = 0</param>
    public void Initialize(int exp = 0)
    {
        Level = new LevelInfo();
        Level.CurrentExperience = exp;
        Level.LevelUpEvent += OnLevelUp;

        _intelligence = BoundaryStats.Intelligence.MinValue;
        _strength = BoundaryStats.Strength.MinValue;
        _constitution = BoundaryStats.Constitution.MinValue;
        _dexterity = BoundaryStats.Dexterity.MinValue;
    }

    public void OnLevelUp()
    {
        SkillPoints += 5;
    }

    public delegate void OnCharacteristicChangeDelegate(double value);

    public event OnCharacteristicChangeDelegate OnStrengthChangeEvent;
    public event OnCharacteristicChangeDelegate OnDexterityChangeEvent;
    public event OnCharacteristicChangeDelegate OnConstitutionChangeEvent;
    public event OnCharacteristicChangeDelegate OnIntelligenceChangeEvent;
}