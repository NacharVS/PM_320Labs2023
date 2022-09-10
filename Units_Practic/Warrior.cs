using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic
{
    public class Warrior : Unit
    {
        public Warrior()
        {
            characteristics = new Characteristics(Units.Warrior);
            healthPoint = characteristics.HealthUpdate(Units.Warrior);
            manaPoint = characteristics.ManaUpdate(Units.Warrior);
            atackPoint = characteristics.AttackUpdate(Units.Warrior);
            magicAtackPoint = characteristics.ManaAttackUpdate(Units.Warrior);
            physicalProtectionPoint = characteristics.PhysicalProtectionUpdate(Units.Warrior);
        }
    }
}
