// Turushkin Sergey, 320P, "EditUnit"

namespace Units_Practic
{
    public class Rogue : Unit
    {
        public Rogue()
        {
            characteristics = new Characteristics(Units.Rogue);
            healthPoint = characteristics.HealthUpdate(Units.Rogue);
            manaPoint = characteristics.ManaUpdate(Units.Rogue);
            atackPoint = characteristics.AttackUpdate(Units.Rogue);
            magicAtackPoint = characteristics.ManaAttackUpdate(Units.Rogue);
            physicalProtectionPoint = characteristics.PhysicalProtectionUpdate(Units.Rogue);
        }
    }
}
