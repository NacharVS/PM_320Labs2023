using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public abstract class CharacterBase
{
    private int _skillPoints = 5;
    public int SkillPoints => _skillPoints;

    private int _strength;

    public int Strength
    {
        get => _strength;
        set
        {
            if (!CanChange(StrengthInfo.Range, _strength, value))
                return;

            _skillPoints -= value - _strength;
            _strength = value;
        }
    }

    public StrengthInfo StrengthInfo { get; protected set; }
    
    private int _dexterity;

    public int Dexterity
    {
        get => _dexterity;
        set
        {
            if (!CanChange(DexterityInfo.Range, _dexterity, value))
                return;

            _skillPoints -= value - _dexterity;
            _dexterity = value;
        }
    }

    public DexterityInfo DexterityInfo { get; protected set; }

    private int _constitution;
    public int Constitution
    {
        get => _constitution;
        set
        {
            if (!CanChange(ConstitutionInfo.Range, _constitution, value))
                return;

            _skillPoints -= value - _constitution;
            _constitution = value;
        }
    }
    public ConstitutionInfo ConstitutionInfo { get; protected set; }

    private int _intelligence;
    public int Intelligence
    {
        get => _intelligence;
        set
        {
            if (!CanChange(ConstitutionInfo.Range, _intelligence, value))
                return;

            _skillPoints -= value - _intelligence;
            _intelligence = value;
        }
    }
    public IntelligenceInfo IntelligenceInfo { get; protected set; }

    public double Health => Strength * StrengthInfo.HpChange +
                            Constitution * ConstitutionInfo.HpChange;

    public double Mana => Intelligence * IntelligenceInfo.ManaChange;

    public double AttackDamage => Strength * StrengthInfo.AttackChange +
                                  Dexterity * DexterityInfo.AttackChange;

    public double MagicalAttackDamage =>
        Intelligence * IntelligenceInfo.MagicalAttackChange;

    public double PhysicalResistance =>
        Constitution * ConstitutionInfo.PhysicalDefenceChange +
        Dexterity * DexterityInfo.PhysicalDefenceChange;

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
        _strength = StrengthInfo.Range.MinValue;
        _dexterity = DexterityInfo.Range.MinValue;
        _constitution = ConstitutionInfo.Range.MinValue;
        _intelligence = IntelligenceInfo.Range.MinValue;
    }
}