using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public abstract class CharacterBase
{
    private const int InventoryCapacity = 9;
    private const int SkillPointsPerLevel = 5;

    public string? Id { get; set; }
    public string? Name { get; set; }

    public LevelInfo Level { get; }

    private int _skillPoints = 50;
    public int SkillPoints => _skillPoints;

    # region Inventory

    private readonly List<Item> _inventory = new();

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

    public void AddToInventory(Item item)
    {
        if (_inventory.Count < InventoryCapacity)
        {
            _inventory.Add(item);
        }
    }

    public void DeleteFromInventory(Item item)
    {
        _inventory.Remove(item);
    }

    #endregion

    # region Characteristics

    public abstract CharacteristicsInfo CharacteristicsInfo { get; }

    private int _strength;

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

    private int _dexterity;

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

    private int _constitution;

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

    private int _intelligence;

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

    #endregion

    # region Stats

    public double Health { get; private set; }

    public double Mana { get; private set; }

    public double AttackDamage { get; private set; }

    public double MagicalAttackDamage { get; private set; }

    public double PhysicalResistance { get; private set; }

    #endregion

    public CharacterBase(int experience = 0)
    {
        Level = new LevelInfo();
        Level.OnLevelUp += OnLevelUp;
        Level.CurrentExperience += experience;
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

    private void OnLevelUp()
    {
        _skillPoints += SkillPointsPerLevel;
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

    public event CharacteristicChangeEventHandler? OnStrengthChange;
    public event CharacteristicChangeEventHandler? OnDexterityChange;
    public event CharacteristicChangeEventHandler? OnConstitutionChange;
    public event CharacteristicChangeEventHandler? OnIntelligenceChange;
}

public delegate void CharacteristicChangeEventHandler(CharacterBase sender,
    CharacteristicChangeEventArgs args);