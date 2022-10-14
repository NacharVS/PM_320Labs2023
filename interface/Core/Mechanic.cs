using Interfaces;

namespace Units

{
    public class Mechanic
    {
        public void Repaire(IRepairable weapon)
        {
            weapon.Repaire();
        }

        public void Upgrade(IUpgradable weapon)
        {
            weapon.Upgrade();
        }
    }
}
