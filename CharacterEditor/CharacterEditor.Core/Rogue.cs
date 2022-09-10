using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class Rogue : CharacterBase
{
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
        StrengthInfo = new StrengthInfo(StrengthRange, StrengthAttackChange, StrengthHpChange);
        DexterityInfo = new DexterityInfo(DexterityRange, DexterityAttackChange, DexterityPhysicalResistanceChange);
        ConstitutionInfo = new ConstitutionInfo(ConstitutionRange, ConstitutionHpChange,
            ConstitutionPhysicalDefenceChange);
        IntelligenceInfo = new IntelligenceInfo(IntelligenceRange,
            IntelligenceManaChange, IntelligenceMagicalAttackChange);
        InitStats();
    }
}