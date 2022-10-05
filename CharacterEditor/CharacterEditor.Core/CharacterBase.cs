using CharacterEditor.Core.Characteristics;
using CharacterEditor.Core.Misc;

namespace CharacterEditor.Core;

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

    public string? Id { get; set; }
    public string? Name { get; set; }
    public LevelInfo Level { get; }
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

    public double Health { get; private set; }
    public double Mana { get; private set; }
    public double AttackDamage { get; private set; }
    public double MagicalAttackDamage { get; private set; }
    public double PhysicalResistance { get; private set; }

    protected CharacterBase(int experience = 0)
    {
        Level = new LevelInfo();
        Level.OnLevelUp += OnLevelUp;
        Level.CurrentExperience += experience;
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
            OnChangeStats?.Invoke(this, item, StatChangeType.Positive);
        }
    }

    public bool CanAddItem(Item item) =>
        _inventory.Count < InventoryCapacity && Inventory.FirstOrDefault(x => x.Type == item.Type) == null;

    public void DeleteFromInventory(Item item)
    {
        _inventory.Remove(item);
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