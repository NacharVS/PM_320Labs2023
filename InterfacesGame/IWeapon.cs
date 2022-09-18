using System;
namespace InterfacesGame
{
    public interface IWeapon : IReloadeble, IUpgradeble, IRepairable
    {
        public void DealDamage();
    }
}
