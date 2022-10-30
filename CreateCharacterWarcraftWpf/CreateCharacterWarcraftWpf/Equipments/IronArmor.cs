namespace CreateCharacterWarcraftWpf.Equipments
{
    public class IronArmor : Equipments
    {
        public IronArmor()
        {
            ReqStrength = 30;
            ReqDexterity = 25;
            ReqConstitution = 25;
            ReqIntelligence = 30;

            StrengthBuff = 4;
            DexterityBuff = 4;
            ConstitutionBuff = 3;
            IntelligenceBuff = 4;

            HealthPointsBuff = 25;
            ManaPointsBuff = 0;
            AttackBuff = 0;
            EquipmentLevel = 2;
            EquipmentName = "Iron Armor";
            EquipmentType = "Breastplate";
        }
    }
}