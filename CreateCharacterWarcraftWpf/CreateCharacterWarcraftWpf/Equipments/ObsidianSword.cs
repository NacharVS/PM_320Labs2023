namespace CreateCharacterWarcraftWpf.Equipments
{
    public class ObsidianSword : Equipments
    {
        public ObsidianSword()
        {
            ReqStrength = 50;
            ReqDexterity = 45;
            ReqConstitution = 45;
            ReqIntelligence = 45;

            StrengthBuff = 9;
            DexterityBuff = 9;
            ConstitutionBuff = 9;
            IntelligenceBuff = 9;

            HealthPointsBuff = 0;
            ManaPointsBuff = 20;
            AttackBuff = 80;
            EquipmentLevel = 3;
            EquipmentName = "Obsidian sword";
            EquipmentType = "Weapon";
        }
    }
}