namespace CharacterEditor.Core.Characteristics;

public class Stats
{
    public StrengthInfo StrengthInfo { get; }
    public DexterityInfo DexterityInfo { get; }
    public ConstitutionInfo ConstitutionInfo { get; }
    public IntelligenceInfo IntelligenceInfo { get; }

    public Stats(StrengthInfo strengthInfo, DexterityInfo dexterityInfo,
        ConstitutionInfo constitutionInfo, IntelligenceInfo intelligenceInfo)
    {
        StrengthInfo = strengthInfo;
        DexterityInfo = dexterityInfo;
        ConstitutionInfo = constitutionInfo;
        IntelligenceInfo = intelligenceInfo;
    }
}