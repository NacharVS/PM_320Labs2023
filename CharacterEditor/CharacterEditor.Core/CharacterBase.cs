using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public abstract class CharacterBase
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    private int _skillPoints = 50;
    public int SkillPoints => _skillPoints;

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

            _skillPoints -= value - _strength;
            _strength = value;
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

            _skillPoints -= value - _dexterity;
            _dexterity = value;
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

            _skillPoints -= value - _constitution;
            _constitution = value;
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

            _skillPoints -= value - _intelligence;
            _intelligence = value;
        }
    }

    #endregion

    # region Stats

    public double Health =>
        Strength * CharacteristicsInfo.StrengthInfo.HpChange +
        Constitution * CharacteristicsInfo.ConstitutionInfo.HpChange;

    public double Mana =>
        Intelligence * CharacteristicsInfo.IntelligenceInfo.ManaChange;

    public double AttackDamage =>
        Strength * CharacteristicsInfo.StrengthInfo.AttackChange +
        Dexterity * CharacteristicsInfo.DexterityInfo.AttackChange;

    public double MagicalAttackDamage =>
        Intelligence * CharacteristicsInfo.IntelligenceInfo.MagicalAttackChange;

    public double PhysicalResistance =>
        Constitution *
        CharacteristicsInfo.ConstitutionInfo.PhysicalDefenceChange +
        Dexterity * CharacteristicsInfo.DexterityInfo.PhysicalDefenceChange;

    #endregion

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

    protected void InitStats()
    {
        _strength = CharacteristicsInfo.StrengthInfo.Range.MinValue;
        _dexterity = CharacteristicsInfo.DexterityInfo.Range.MinValue;
        _constitution = CharacteristicsInfo.ConstitutionInfo.Range.MinValue;
        _intelligence = CharacteristicsInfo.IntelligenceInfo.Range.MinValue;
    }
}