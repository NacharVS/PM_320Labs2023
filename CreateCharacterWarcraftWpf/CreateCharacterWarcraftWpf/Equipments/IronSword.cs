namespace CreateCharacterWarcraftWpf.Equipments
{
    public class IronSword : Equipments
    {
        public IronSword()
        {
            ReqStrength = 30;
            ReqDexterity = 30;
            ReqConstitution = 25;
            ReqIntelligence = 25;

            StrengthBuff = 3;
            DexterityBuff = 3;
            ConstitutionBuff = 3;
            IntelligenceBuff = 3;

            HealthPointsBuff = 0;
            ManaPointsBuff = 5;
            AttackBuff = 55;
            EquipmentLevel = 2;
            EquipmentName = "Iron sword";
            EquipmentType = "Weapon";
        }
    }
}