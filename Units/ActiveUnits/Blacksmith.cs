using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units.BaseUnits;

namespace Units.ActiveUnits
{
    public class Blacksmith : Unit
    {
        private static int _boost = 3;

        public delegate void OnArmorUpgradeDelegate();
        public event OnArmorUpgradeDelegate OnArmorUpgradeEvent;

        public delegate void OnWeaponUpgradeDelegate();
        public event OnWeaponUpgradeDelegate OnWeaponUpgradeEvent;

        public Blacksmith(double health, string name) : base(name, health)
        {
            OnArmorUpgradeEvent += 
                () => Console.WriteLine("Unit's armors were upgraded!");

            OnWeaponUpgradeEvent +=
                () => Console.WriteLine("Unit's weapons were upgraded!");
        }
        public void UpgradeArmor(List<Unit> listOfUnits)
        {
            foreach (Unit unit in listOfUnits)
            {
                if(unit is Military)
                {
                    ((Military)unit).SetArmor(((Military)unit).GetArmor() + _boost);
                    ((Military)unit).SetMaxArmor(((Military)unit).GetMaxArmor() + _boost);
                }
            }
            OnArmorUpgradeEvent?.Invoke();
        }

        public void UpgradeWeapon(List<Unit> listOfUnits)
        {
            foreach (var unit in listOfUnits)
            {
                if (unit is BaseUnits.Range || unit is not Military)
                {
                }
                else
                {
                    ((Military)unit).SetDamage(((Military)unit).GetDamage() + _boost);
                    ((Military)unit).SetMaxDamage(((Military)unit).GetMaxDamage() + _boost);
                }
            }
            OnWeaponUpgradeEvent?.Invoke();
        }

        public void UprgradeBow(List<Archer> listOfArchers)
        {
            foreach (var archer in listOfArchers)
            {
                archer.SetDamage(archer.GetDamage() + _boost);
                archer.SetMaxDamage(archer.GetMaxDamage() + _boost);
            }
        }
    }
}
