namespace CreateCharacterWarcraftWpf.Equipments
{
    public class ObsidianArmor : Equipments
    {
        public ObsidianArmor()
        {
            ReqStrength = 90;
            ReqDexterity = 75;
            ReqConstitution = 75;
            ReqIntelligence = 45;

            StrengthBuff = 3;
            DexterityBuff = 10;
            ConstitutionBuff = 10;
            IntelligenceBuff = 3;

            HealthPointsBuff = 80;
            ManaPointsBuff = 50;
            AttackBuff = 0;
            EquipmentLevel = 3;
            EquipmentName = "Obsidian Armor";
            EquipmentType = "Breastplate";
        }
    }
}