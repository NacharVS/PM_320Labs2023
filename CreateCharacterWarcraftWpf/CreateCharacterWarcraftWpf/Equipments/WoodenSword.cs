namespace CreateCharacterWarcraftWpf.Equipments
{
    public class WoodenSword : Equipments
    {
        public WoodenSword()
        {
            ReqStrength = 10;
            ReqDexterity = 15;
            ReqConstitution = 15;
            ReqIntelligence = 15;

            StrengthBuff = 2;
            DexterityBuff = 2;
            ConstitutionBuff = 2;
            IntelligenceBuff = 1;

            HealthPointsBuff = 0;
            ManaPointsBuff = 0;
            AttackBuff = 25;
            EquipmentLevel = 1;
            EquipmentName = "Wooden sword";
            EquipmentType = "Weapon";
        }
    }
}