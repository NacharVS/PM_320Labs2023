namespace CreateCharacterWarcraftWpf.Equipments
{
    public class ObsidianHelmet : Equipments
    {
        public ObsidianHelmet()
        {
            ReqStrength = 75;
            ReqDexterity = 65;
            ReqConstitution = 65;
            ReqIntelligence = 45;

            StrengthBuff = 8;
            DexterityBuff = 8;
            ConstitutionBuff = 8;
            IntelligenceBuff = 8;

            HealthPointsBuff = 35;
            ManaPointsBuff = 30;
            AttackBuff = 25;
            EquipmentLevel = 3;
            EquipmentName = "Obsidian Helmet";
            EquipmentType = "Helmet";
        }
    }
}