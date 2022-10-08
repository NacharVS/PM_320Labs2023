namespace CharacterEditor.Core.Characteristics;

/// <summary>
/// Contains all character characteristics options (stat change, minimum and maximum limits)
/// </summary>
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