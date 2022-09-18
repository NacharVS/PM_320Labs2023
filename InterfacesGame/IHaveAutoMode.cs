using System;
namespace InterfacesGame
{
    public interface IHaveAutoMade : IRangedWeapon, IWeapon
    {
        public void AutoModeShoot();
    }
}
