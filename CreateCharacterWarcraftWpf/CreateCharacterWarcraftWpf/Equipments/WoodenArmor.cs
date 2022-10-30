namespace CreateCharacterWarcraftWpf.Equipments
{
    public class WoodenArmor : Equipments
    {
        public WoodenArmor()
        {
            ReqStrength = 20;
            ReqDexterity = 10;
            ReqConstitution = 10;
            ReqIntelligence = 5;

            StrengthBuff = 1;
            DexterityBuff = 1;
            ConstitutionBuff = 1;
            IntelligenceBuff = 1;

            HealthPointsBuff = 10;
            ManaPointsBuff = 0;
            AttackBuff = 0;
            EquipmentLevel = 1;
            EquipmentName = "Wooden Armor";
            EquipmentType = "Breastplate";
        }
    }
}