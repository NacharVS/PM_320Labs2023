// Turushkin Sergey, 320P, "EditUnit"

namespace Units_Practic
{
    public class Warrior : Unit
    {
        public Warrior()
        {
            characteristics = new Characteristics(Units.Warrior);
            UpdateHaracteristics();
        }

        public override void UpdateHaracteristics()
        {
            healthPoint = characteristics.HealthUpdate(Units.Warrior);
            manaPoint = characteristics.ManaUpdate(Units.Warrior);
            atackPoint = characteristics.AttackUpdate(Units.Warrior);
            magicAtackPoint = characteristics.ManaAttackUpdate(Units.Warrior);
            physicalProtectionPoint = characteristics.PhysicalProtectionUpdate(Units.Warrior);
        }
    }
}
