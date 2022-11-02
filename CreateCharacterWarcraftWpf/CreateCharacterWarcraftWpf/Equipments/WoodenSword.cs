namespace CreateCharacterWarcraftWpf.Equipments
{
    public class WoodenSword : Equipments
    {
        public WoodenSword()
        {
            ReqStrength = 20;
            ReqDexterity = 25;
            ReqConstitution = 25;
            ReqIntelligence = 25;

            StrengthBuff = 2;
            DexterityBuff = 2;
            ConstitutionBuff = 2;
            IntelligenceBuff = 1;

            AttackBuff = 25;
            EquipmentLevel = 1;
            EquipmentName = "Wooden sword";
            EquipmentType = "Weapon";
        }
    }
}