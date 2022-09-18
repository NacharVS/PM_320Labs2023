using System;
namespace InterfacesGame
{
    public class Mechanic
    {
        public Mechanic()
        {
        }

        public void UpgradeWeapon(IUpgradeble weapon)
        {
            weapon.Upgrade();
        }

        public void RepairWeapon(IRepairable weapon)
        {
            weapon.Repair();
        }

        public void ShowInfo(IRepairable weapon)
        {
            weapon.ShowInfo();
        }
    }
}
