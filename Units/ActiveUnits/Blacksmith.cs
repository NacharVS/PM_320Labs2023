using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public static class Blacksmith
    {
        private static int _boost = 3;

        public static void UpgradeArmor(List<Military> listOfUnits)
        {
            foreach (var unit in listOfUnits)
            {
                unit.SetArmor(unit.GetArmor() + _boost);
                unit.SetMaxArmor(unit.GetMaxArmor() + _boost);
            }
        }

        public static void UpgradeWeapon(List<Military> listOfUnits)
        {
            foreach (var unit in listOfUnits)
            {
                if (unit is Range)
                {
                    return;
                }
                unit.SetDamage(unit.GetDamage() + _boost);
                unit.SetMaxDamage(unit.GetMaxDamage() + _boost);
            }
        }

        public static void UprgradeBow(List<Archer> listOfArchers)
        {
            foreach (var archer in listOfArchers)
            {
                archer.SetDamage(archer.GetDamage() + _boost);
                archer.SetMaxDamage(archer.GetMaxDamage() + _boost);
            }
        }
    }
}
