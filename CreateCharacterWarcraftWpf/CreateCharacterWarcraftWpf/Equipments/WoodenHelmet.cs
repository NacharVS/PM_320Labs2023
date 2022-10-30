namespace CreateCharacterWarcraftWpf.Equipments
{
    public class WoodenHelmet : Equipments
    {
        public WoodenHelmet()
        {
            ReqStrength = 20;
            ReqDexterity = 15;
            ReqConstitution = 15;
            ReqIntelligence = 5;

            StrengthBuff = 2;
            DexterityBuff = 1;
            ConstitutionBuff = 2;
            IntelligenceBuff = 1;

            HealthPointsBuff = 5;
            ManaPointsBuff = 0;
            AttackBuff = 1;
            EquipmentLevel = 1;
            EquipmentName = "Wooden Helmet";
            EquipmentType = "Helmet";
        }
    }
}