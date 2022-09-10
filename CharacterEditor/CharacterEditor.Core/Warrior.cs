using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class Warrior : CharacterBase
{
    private static readonly CharacteristicRange StrengthRange = new(30, 250);
    private const double StrengthAttackChange = 5;
    private const double StrengthHpChange = 2;

    private static readonly CharacteristicRange DexterityRange = new(15, 70);
    private const double DexterityAttackChange = 1;
    private const double DexterityPhysicalResistanceChange = 1;
    
    private static readonly CharacteristicRange ConstitutionRange = new(15, 70);
    private const double ConstitutionHpChange = 10;
    private const double ConstitutionPhysicalDefenceChange = 2;
    
    private static readonly CharacteristicRange IntelligenceRange = new(15, 70);
    private const double IntelligenceManaChange = 1;
    private const double IntelligenceMagicalAttackChange = 1;

    static Warrior()
    {
        StrengthInfo = new StrengthInfo(StrengthRange, StrengthAttackChange, StrengthHpChange);
        DexterityInfo = new DexterityInfo(DexterityRange, DexterityAttackChange, DexterityPhysicalResistanceChange);
        ConstitutionInfo = new ConstitutionInfo(ConstitutionRange, ConstitutionHpChange,
            ConstitutionPhysicalDefenceChange);
        IntelligenceInfo = new IntelligenceInfo(IntelligenceRange,
            IntelligenceManaChange, IntelligenceMagicalAttackChange);
    }
}