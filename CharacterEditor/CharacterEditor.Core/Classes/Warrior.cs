﻿using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core.Classes;

public class Warrior : Character
{
    public sealed override CharacteristicsInfo CharacteristicsInfo { get; }

    private static readonly CharacteristicRange StrengthRange = new(30, 250);
    private const double StrengthAttackChange = 5;
    private const double StrengthHpChange = 2;

    private static readonly CharacteristicRange DexterityRange = new(15, 70);
    private const double DexterityAttackChange = 1;
    private const double DexterityPhysicalResistanceChange = 1;

    private static readonly CharacteristicRange
        ConstitutionRange = new(20, 100);

    private const double ConstitutionHpChange = 10;
    private const double ConstitutionPhysicalDefenceChange = 2;

    private static readonly CharacteristicRange IntelligenceRange = new(10, 50);
    private const double IntelligenceManaChange = 1;
    private const double IntelligenceMagicalAttackChange = 1;

    public Warrior(int experience=0) : base(experience)
    {
        Name = nameof(Warrior);
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