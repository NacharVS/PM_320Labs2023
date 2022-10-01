// Turushkin Sergey, 320P, "EditUnit"

namespace Units_Practic
{
    public class Wizard : Unit
    {
        public Wizard()
        {
            characteristics = new Characteristics(Units.Wizard);
            UpdateHaracteristics();
        }

        public override void UpdateHaracteristics()
        {
            healthPoint = characteristics.HealthUpdate(Units.Wizard);
            manaPoint = characteristics.ManaUpdate(Units.Wizard);
            atackPoint = characteristics.AttackUpdate(Units.Wizard);
            magicAtackPoint = characteristics.ManaAttackUpdate(Units.Wizard);
            physicalProtectionPoint = characteristics.PhysicalProtectionUpdate(Units.Wizard);
        }
    }
}
