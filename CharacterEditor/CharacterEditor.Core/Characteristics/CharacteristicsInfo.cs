namespace CharacterEditor.Core.Characteristics;

public class CharacteristicsInfo
{
    public StrengthInfo StrengthInfo { get; }
    public DexterityInfo DexterityInfo { get; }
    public ConstitutionInfo ConstitutionInfo { get; }
    public IntelligenceInfo IntelligenceInfo { get; }

    public CharacteristicsInfo(StrengthInfo strengthInfo, DexterityInfo dexterityInfo,
        ConstitutionInfo constitutionInfo, IntelligenceInfo intelligenceInfo)
    {
        StrengthInfo = strengthInfo;
        DexterityInfo = dexterityInfo;
        ConstitutionInfo = constitutionInfo;
        IntelligenceInfo = intelligenceInfo;
    }
}