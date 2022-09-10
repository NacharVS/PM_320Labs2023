using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public abstract class CharacterBase
{
    public int Strength { get; set; }
    public static StrengthInfo StrengthInfo { get; protected set; }
    public int Dexterity { get; set; }
    public static DexterityInfo DexterityInfo { get; protected set; }
    public int Constitution { get; set; }
    public static ConstitutionInfo ConstitutionInfo { get; protected set; }
    public int Intelligence { get; set; }
    public static IntelligenceInfo IntelligenceInfo { get; protected set; }

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
}