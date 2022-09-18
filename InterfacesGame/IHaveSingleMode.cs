using System;
namespace InterfacesGame
{
    public interface IHaveSingleMode : IRangedWeapon, IWeapon
    {
        public void SingleShoot();
    }
}
