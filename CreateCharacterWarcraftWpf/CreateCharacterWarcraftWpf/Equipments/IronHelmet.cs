namespace CreateCharacterWarcraftWpf.Equipments
{
    public class IronHelmet : Equipments
    {
        public IronHelmet()
        {
            ReqStrength = 30;
            ReqDexterity = 25;
            ReqConstitution = 30;
            ReqIntelligence = 25;

            StrengthBuff = 3;
            DexterityBuff = 4;
            ConstitutionBuff = 4;
            IntelligenceBuff = 3;

            HealthPointsBuff = 10;
            ManaPointsBuff = 0;
            AttackBuff = 5;
            EquipmentLevel = 2;
            EquipmentName = "Iron Helmet";
            EquipmentType = "Helmet";
        }
    }
}