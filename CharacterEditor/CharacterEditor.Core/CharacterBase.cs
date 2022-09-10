using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public abstract class CharacterBase
{
    private int _skillPoints = 5;
    public int SkillPoints => _skillPoints;

    protected abstract Stats Stats { get; set; }

    private int _strength;

    public int Strength
    {
        get => _strength;
        set
        {
            if (!CanChange(Stats.StrengthInfo.Range, _strength, value))
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
            if (!CanChange(Stats.DexterityInfo.Range, _dexterity, value))
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
            if (!CanChange(Stats.ConstitutionInfo.Range, _constitution, value))
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
            if (!CanChange(Stats.IntelligenceInfo.Range, _intelligence, value))
                return;

            _skillPoints -= value - _intelligence;
            _intelligence = value;
        }
    }

    public double Health => Strength * Stats.StrengthInfo.HpChange +
                            Constitution * Stats.ConstitutionInfo.HpChange;

    public double Mana => Intelligence * Stats.IntelligenceInfo.ManaChange;

    public double AttackDamage => Strength * Stats.StrengthInfo.AttackChange +
                                  Dexterity * Stats.DexterityInfo.AttackChange;

    public double MagicalAttackDamage =>
        Intelligence * Stats.IntelligenceInfo.MagicalAttackChange;

    public double PhysicalResistance =>
        Constitution * Stats.ConstitutionInfo.PhysicalDefenceChange +
        Dexterity * Stats.DexterityInfo.PhysicalDefenceChange;

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
        _strength = Stats.StrengthInfo.Range.MinValue;
        _dexterity = Stats.DexterityInfo.Range.MinValue;
        _constitution = Stats.ConstitutionInfo.Range.MinValue;
        _intelligence = Stats.IntelligenceInfo.Range.MinValue;
    }
}