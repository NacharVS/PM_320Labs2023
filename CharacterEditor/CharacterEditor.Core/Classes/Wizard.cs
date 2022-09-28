using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class Wizard : CharacterBase
{
    public sealed override CharacteristicsInfo CharacteristicsInfo { get; }
    private static readonly CharacteristicRange StrengthRange = new(10, 45);
    private const double StrengthAttackChange = 3;
    private const double StrengthHpChange = 1;

    private static readonly CharacteristicRange DexterityRange = new(20, 70);
    private const double DexterityAttackChange = 0;
    private const double DexterityPhysicalResistanceChange = 0.5;

    private static readonly CharacteristicRange ConstitutionRange = new(15, 60);
    private const double ConstitutionHpChange = 3;
    private const double ConstitutionPhysicalDefenceChange = 1;

    private static readonly CharacteristicRange
        IntelligenceRange = new(35, 250);

    private const double IntelligenceManaChange = 2;
    private const double IntelligenceMagicalAttackChange = 5;

    public Wizard()
    {
        var strengthInfo = new StrengthInfo(StrengthRange, StrengthAttackChange,
            StrengthHpChange);
        var dexterityInfo = new DexterityInfo(DexterityRange,
            DexterityAttackChange, DexterityPhysicalResistanceChange);
        var constitutionInfo = new ConstitutionInfo(ConstitutionRange,
            ConstitutionHpChange,
            ConstitutionPhysicalDefenceChange);
        var intelligenceInfo = new IntelligenceInfo(IntelligenceRange,
            IntelligenceManaChange, IntelligenceMagicalAttackChange);
        CharacteristicsInfo = new CharacteristicsInfo(strengthInfo, dexterityInfo, constitutionInfo,
            intelligenceInfo);
        InitStats();
    }
}