using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class Rogue : CharacterBase
{
    public sealed override Stats Stats { get; set; }

    private static readonly CharacteristicRange StrengthRange = new(15, 55);
    private const double StrengthAttackChange = 2;
    private const double StrengthHpChange = 1;

    private static readonly CharacteristicRange DexterityRange = new(30, 250);
    private const double DexterityAttackChange = 4;
    private const double DexterityPhysicalResistanceChange = 1.5;

    private static readonly CharacteristicRange ConstitutionRange = new(20, 80);
    private const double ConstitutionHpChange = 6;
    private const double ConstitutionPhysicalDefenceChange = 0;

    private static readonly CharacteristicRange IntelligenceRange = new(15, 70);
    private const double IntelligenceManaChange = 1.5;
    private const double IntelligenceMagicalAttackChange = 2;

    public Rogue()
    {
        var strengthInfo = new StrengthInfo(StrengthRange, StrengthAttackChange,
            StrengthHpChange);
        var dexterityInfo = new DexterityInfo(DexterityRange,
            DexterityAttackChange,
            DexterityPhysicalResistanceChange);
        var constitutionInfo = new ConstitutionInfo(ConstitutionRange,
            ConstitutionHpChange,
            ConstitutionPhysicalDefenceChange);
        var intelligenceInfo = new IntelligenceInfo(IntelligenceRange,
            IntelligenceManaChange, IntelligenceMagicalAttackChange);

        Stats = new Stats(strengthInfo, dexterityInfo, constitutionInfo,
            intelligenceInfo);
        InitStats();
    }
}