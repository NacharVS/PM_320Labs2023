using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class Wizard : CharacterBase
{
    private static readonly CharacteristicRange StrengthRange = new(10, 45);
    private const double StrengthAttackChange = 3;
    private const double StrengthHpChange = 1;

    private static readonly CharacteristicRange DexterityRange = new(20, 70);
    private const double DexterityAttackChange = 0;
    private const double DexterityPhysicalResistanceChange = 0.5;
    
    private static readonly CharacteristicRange ConstitutionRange = new(15, 60);
    private const double ConstitutionHpChange = 3;
    private const double ConstitutionPhysicalDefenceChange = 1;
    
    private static readonly CharacteristicRange IntelligenceRange = new(30, 250);
    private const double IntelligenceManaChange = 2;
    private const double IntelligenceMagicalAttackChange = 5;

    public Wizard()
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