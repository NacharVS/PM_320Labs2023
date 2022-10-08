using CharacterEditor.Core.Characteristics;
using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core;

/// <summary>
/// Base character that contains all logic for Classes 
/// </summary>
public abstract class CharacterBase
{
    private const int InventoryCapacity = 9;
    private const int MaximumAbilityCount = 5;
    private const int SkillPointsPerLevel = 5;
    private const int DefaultSkillPoints = 50;
    private const int AbilityGainLevelInterval = 3;

    private int _skillPoints = DefaultSkillPoints;
    private readonly List<Ability> _abilities = new();
    private readonly List<Item> _inventory = new();
    private int _strength;
    private int _dexterity;
    private int _constitution;
    private int _intelligence;

    /// <summary>
    /// Unique identifier for character
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Character name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Class that contains all levelling logic
    /// </summary>
    public LevelInfo Level { get; }
    
    /// <summary>
    /// Skill points that can be spent on gaining Characteristics
    /// </summary>
    public int SkillPoints => _skillPoints;

    public Ability[] Abilities
    {
        get => _abilities.ToArray();
        set
        {
            foreach (var ability in value)
            {
                AddAbility(ability);
            }
        }
    }

    public Item[] Inventory
    {
        get => _inventory.ToArray();
        set
        {
            foreach (var item in value)
            {
                AddToInventory(item);
            }
        }
    }

    public abstract CharacteristicsInfo CharacteristicsInfo { get; }

    #region Characteristics

    public int Strength
    {
        get => _strength;
        set
        {
            if (!CanChange(CharacteristicsInfo.StrengthInfo.Range, _strength,
                    value))
                return;

            var skillPointsTaken = value - _strength;
            _skillPoints -= skillPointsTaken;
            _strength = value;
            OnStrengthChange?.Invoke(this,
                new CharacteristicChangeEventArgs(skillPointsTaken));
        }
    }

    public int Dexterity
    {
        get => _dexterity;
        set
        {
            if (!CanChange(CharacteristicsInfo.DexterityInfo.Range, _dexterity,
                    value))
                return;

            var skillPointsTaken = value - _dexterity;
            _skillPoints -= skillPointsTaken;
            _dexterity = value;
            OnDexterityChange?.Invoke(this,
                new CharacteristicChangeEventArgs(skillPointsTaken));
        }
    }

    public int Constitution
    {
        get => _constitution;
        set
        {
            if (!CanChange(CharacteristicsInfo.ConstitutionInfo.Range,
                    _constitution, value))
                return;

            var skillPointsTaken = value - _constitution;
            _skillPoints -= skillPointsTaken;
            _constitution = value;
            OnConstitutionChange?.Invoke(this,
                new CharacteristicChangeEventArgs(skillPointsTaken));
        }
    }

    public int Intelligence
    {
        get => _intelligence;
        set
        {
            if (!CanChange(CharacteristicsInfo.IntelligenceInfo.Range,
                    _intelligence, value))
                return;

            var skillPointsTaken = value - _intelligence;
            _skillPoints -= skillPointsTaken;
            _intelligence = value;
            OnIntelligenceChange?.Invoke(this,
                new CharacteristicChangeEventArgs(skillPointsTaken));
        }
    }

    private int _additionalStrength;

    public int AdditionalStrength
    {
        get => _additionalStrength;
        private set
        {
            var difference = value - _additionalStrength;
            _additionalStrength = value;
            AdditionalHealth += difference *
                                CharacteristicsInfo.StrengthInfo.HpChange;
            AdditionalAttackDamage += difference *
                                      CharacteristicsInfo.StrengthInfo
                                          .AttackChange;
        }
    }

    private int _additionalDexterity;

    public int AdditionalDexterity
    {
        get => _additionalDexterity;
        private set
        {
            var difference = value - _additionalDexterity;
            _additionalDexterity = value;
            AdditionalAttackDamage += difference *
                                      CharacteristicsInfo.DexterityInfo
                                          .AttackChange;
            AdditionalPhysicalResistance += difference *
                                            CharacteristicsInfo.DexterityInfo
                                                .PhysicalDefenceChange;
        }
    }

    private int _additionalConstitution;

    public int AdditionalConstitution
    {
        get => _additionalConstitution;
        private set
        {
            var difference = value - _additionalConstitution;
            _additionalConstitution = value;
            AdditionalHealth += difference *
                                CharacteristicsInfo.ConstitutionInfo.HpChange;
            AdditionalPhysicalResistance += difference * CharacteristicsInfo
                .ConstitutionInfo.PhysicalDefenceChange;
        }
    }

    private int _additionalIntelligence;

    public int AdditionalIntelligence
    {
        get => _additionalIntelligence;
        private set
        {
            var difference = value - _additionalIntelligence;
            _additionalIntelligence = value;
            AdditionalMana += difference *
                              CharacteristicsInfo.IntelligenceInfo.ManaChange;
            AdditionalMagicalAttackDamage += difference * CharacteristicsInfo
                .IntelligenceInfo.MagicalAttackChange;
        }
    }

    #endregion

    #region Stats

    public double Health { get; private set; }
    public double Mana { get; private set; }
    public double AttackDamage { get; private set; }
    public double MagicalAttackDamage { get; private set; }
    public double PhysicalResistance { get; private set; }

    public double AdditionalHealth { get; private set; }
    public double AdditionalMana { get; private set; }
    public double AdditionalAttackDamage { get; private set; }
    public double AdditionalMagicalAttackDamage { get; private set; }
    public double AdditionalPhysicalResistance { get; private set; }

    #endregion

    protected CharacterBase(int experience = 0)
    {
        Level = new LevelInfo();
        Level.OnLevelUp += OnLevelUp;
        Level.CurrentExperience += experience;
        OnInventoryUpdate += (item, operation) =>
        {
            AdditionalStrength += item.StrengthChange * (int)operation;
            AdditionalDexterity += item.DexterityChange * (int)operation;
            AdditionalConstitution += item.ConstitutionChange * (int)operation;
            AdditionalIntelligence += item.IntelligenceChange * (int)operation;
        };

        OnChangeStats += (_, entity, changeType) =>
        {
            Health += entity.HealthChange * (int)changeType;
            AttackDamage += entity.AttackChange * (int)changeType;
            Mana += entity.ManaChange * (int)changeType;
            MagicalAttackDamage += entity.MagicalAttackChange * (int)changeType;
            PhysicalResistance +=
                entity.PhysicalResistanceChange * (int)changeType;
        };
        OnStrengthChange += (_, args) =>
        {
            Health += args.Difference *
                      CharacteristicsInfo.StrengthInfo.HpChange;
            AttackDamage += args.Difference *
                            CharacteristicsInfo.StrengthInfo.AttackChange;
        };

        OnDexterityChange += (_, args) =>
        {
            AttackDamage += args.Difference *
                            CharacteristicsInfo.DexterityInfo.AttackChange;
            PhysicalResistance += args.Difference *
                                  CharacteristicsInfo.DexterityInfo
                                      .PhysicalDefenceChange;
        };

        OnConstitutionChange += (_, args) =>
        {
            Health += args.Difference *
                      CharacteristicsInfo.ConstitutionInfo.HpChange;
            PhysicalResistance += args.Difference * CharacteristicsInfo
                .ConstitutionInfo.PhysicalDefenceChange;
        };

        OnIntelligenceChange += (_, args) =>
        {
            Mana += args.Difference *
                    CharacteristicsInfo.IntelligenceInfo.ManaChange;
            MagicalAttackDamage += args.Difference * CharacteristicsInfo
                .IntelligenceInfo.MagicalAttackChange;
        };
    }

    # region Calcs

    private double CalculateMana(int difference) => difference *
                                                    CharacteristicsInfo
                                                        .IntelligenceInfo
                                                        .ManaChange;

    private double CalculateMagicalAttack(int difference) => difference *
        CharacteristicsInfo.IntelligenceInfo.MagicalAttackChange;

    private double CalculateHealth(int difference) => difference *
        (CharacteristicsInfo.StrengthInfo.HpChange +
         CharacteristicsInfo.ConstitutionInfo.HpChange);

    private double CalculatePhysicalResist(int difference) => difference *
        (CharacteristicsInfo.DexterityInfo.PhysicalDefenceChange +
         CharacteristicsInfo.ConstitutionInfo.PhysicalDefenceChange);

    private double CalculateAttack(int difference) => difference *
        (CharacteristicsInfo.StrengthInfo.AttackChange +
         CharacteristicsInfo.DexterityInfo.AttackChange);

    #endregion

    public void AddAbility(Ability ability)
    {
        if (_abilities.Count < MaximumAbilityCount)
        {
            _abilities.Add(ability);
            OnChangeStats?.Invoke(this, ability, StatChangeType.Positive);
        }
    }

    public void AddToInventory(Item item)
    {
        if (CanAddItem(item))
        {
            _inventory.Add(item);
            OnInventoryUpdate?.Invoke(item, InventoryOperation.Add);
            OnChangeStats?.Invoke(this, item, StatChangeType.Positive);
        }
    }

    public bool CanAddItem(Item item) =>
        _inventory.Count < InventoryCapacity &&
        (item.Type == ItemType.Universal || item.Type != ItemType.Universal &&
        Inventory.FirstOrDefault(x => x.Type == item.Type) == null);

    public void DeleteFromInventory(Item item)
    {
        _inventory.Remove(item);
        OnInventoryUpdate?.Invoke(item, InventoryOperation.Remove);
        OnChangeStats?.Invoke(this, item, StatChangeType.Negative);
    }

    protected void InitStats()
    {
        _strength = CharacteristicsInfo.StrengthInfo.Range.MinValue;
        _dexterity = CharacteristicsInfo.DexterityInfo.Range.MinValue;
        _constitution = CharacteristicsInfo.ConstitutionInfo.Range.MinValue;
        _intelligence = CharacteristicsInfo.IntelligenceInfo.Range.MinValue;

        OnStrengthChange?.Invoke(this,
            new CharacteristicChangeEventArgs(CharacteristicsInfo.StrengthInfo
                .Range.MinValue));
        OnDexterityChange?.Invoke(this,
            new CharacteristicChangeEventArgs(CharacteristicsInfo.DexterityInfo
                .Range.MinValue));
        OnConstitutionChange?.Invoke(this,
            new CharacteristicChangeEventArgs(CharacteristicsInfo
                .ConstitutionInfo.Range.MinValue));
        OnIntelligenceChange?.Invoke(this,
            new CharacteristicChangeEventArgs(CharacteristicsInfo
                .IntelligenceInfo.Range.MinValue));
    }

    private void OnLevelUp()
    {
        _skillPoints += SkillPointsPerLevel;
        if (_abilities.Count < MaximumAbilityCount &&
            Level.CurrentLevel % AbilityGainLevelInterval == 0)
            OnAbilityGain?.Invoke();
    }

    private bool CanChange(CharacteristicRange range, int oldValue,
        int newValue)
    {
        if (!range.ContainsValue(newValue))
            return false;
        if (newValue > oldValue)
        {
            if (newValue - oldValue > _skillPoints)
                return false;
        }

        return true;
    }

    public event UpdateStatEventHandler? OnChangeStats;
    public event ItemAddEventHandler? OnInventoryUpdate;
    public event AbilityGainEventHandler? OnAbilityGain;
    public event CharacteristicChangeEventHandler? OnStrengthChange;
    public event CharacteristicChangeEventHandler? OnDexterityChange;
    public event CharacteristicChangeEventHandler? OnConstitutionChange;
    public event CharacteristicChangeEventHandler? OnIntelligenceChange;
}

public delegate void CharacteristicChangeEventHandler(CharacterBase sender,
    CharacteristicChangeEventArgs args);

public delegate void UpdateStatEventHandler(CharacterBase sender,
    ICanChangeStats entity, StatChangeType changeType);

public delegate void AbilityGainEventHandler();

public delegate void ItemAddEventHandler(Item item, InventoryOperation operation);